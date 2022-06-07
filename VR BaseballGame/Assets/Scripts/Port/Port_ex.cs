using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using System.Threading; // 스레드 사용 위해
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.InteropServices;
using System;

public class Port_ex : MonoBehaviour
{

    public GameObject Test_Bat;

    testex testex;

    // 이동평균
    float[] readings = new float[15];
    const int numReadings = 15;
    float total = 0;
    int readIndex = 0;
    float avg = 0;
    int inputPin = 0;





    bool check = false;
    string num1 = "3";
    public enum PortNumber
    {
        COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8
    }

    // 연결된 포트, baud rate (통신 속도)
    private SerialPort serial;
    private string rcv_data = null;

    [SerializeField] private PortNumber portNumber = PortNumber.COM1;
    [SerializeField] private string baudRate = "9600";
    [SerializeField] public string BatNumber;



   

    public string nPort = "COM8";

    private float x;   // 벡터 값   쿼터니언 값 받기
    private float y;
    private float z;
    private float w;

    private float Vx;  // 속도 벡터  
    private float Vy;
    private float Vz;
    //public float encoder_value = 0f;



    Thread myThread;

    void Start()
    {
       


        // 시리얼 포트 초기화 시리얼 통신 과정에서 필요한 코드
        serial = new SerialPort(portNumber.ToString(), int.Parse(baudRate), Parity.None, 8, StopBits.One);
        //serial.Open();
        serial.Open();
        myThread = new Thread(new ThreadStart(GetData));
        myThread.Start();       // 포트가 닫혀도 값이 전송됨

        //serial.WriteTimeout = 10000;  
        for (int thisReading = 0; thisReading < numReadings; thisReading++)
        {
            readings[thisReading] = 0;   // 현재값을 읽는 변수를 0으로 초기화
        }

    }

    void FixedUpdate()
    {




        CalRotate(nPort);



    }

    void GetData()
    {
        while (myThread.IsAlive)
        {

            try
            {
                if (!serial.IsOpen)
                {
                    tryConnectPort();


                }
                else
                {
                    //Debug.Log("연결");
                    rcv_data = serial.ReadLine();
                    testseparate(rcv_data);


                }

            }

            catch (System.Exception e)
            {

            }

        }

    }



    private void tryConnectPort()
    {
        serial.Open();
    }

    void testseparate(string data)
    {
        char[] spl = { ',', '*' };
        string[] strListVal = data.Split(spl, System.StringSplitOptions.RemoveEmptyEntries);




        z = float.Parse(strListVal[0]);  // 벡터 값
        y = float.Parse(strListVal[1]);
        x = float.Parse(strListVal[2]);
        w = float.Parse(strListVal[3]);  // 스칼라 값

        Vx = float.Parse(strListVal[4]); // 속도 벡터
        Vy = float.Parse(strListVal[5]);
        Vz = float.Parse(strListVal[6]);


        Debug.Log("(x, y, z, w, Vx, Vy, Vz) = (" + string.Format("{0:0.##}", x) + ", "
                                          + string.Format("{0:0.##}", y) + ", "
                                          + string.Format("{0:0.##}", z) + ", "
                                          + string.Format("{0:0.##}", w) + ", "
                                          + string.Format("{0:0.##}", Vx) + ", "
                                          + string.Format("{0:0.##}", Vy) + ", "
                                          + string.Format("{0:0.##}", Vz) + ", ");



    }
    float Moving_Avg_Filter(float num)
    {

        total = total - readings[readIndex];
        readings[readIndex] = num;
        total = total + readings[readIndex];
        readIndex = readIndex + 1;

        if (readIndex >= numReadings)
        {
            readIndex = 0;
        }

        avg = total / numReadings;

        return avg;
    }


    private void CalRotate(String nport)    // ahrx 값 가져오기
    {

        Test_Bat.transform.localRotation = new Quaternion(Moving_Avg_Filter(x), Moving_Avg_Filter(y), Moving_Avg_Filter(z), Moving_Avg_Filter(w)); // 이동 평균 내기 배열 써서

    }


    void BatCollision(string str)
    {
        serial.Write(str);
    }


    private void OnApplicationQuit() // 프로그램 종료될 시 포트랑 스레드 꺼줘야함
    {
        serial.Close();
        Debug.Log("종료");
        myThread.Abort();
        myThread.Suspend();

    }
}
