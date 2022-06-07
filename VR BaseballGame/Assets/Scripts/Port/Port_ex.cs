using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using System.Threading; // ������ ��� ����
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.InteropServices;
using System;

public class Port_ex : MonoBehaviour
{

    public GameObject Test_Bat;

    testex testex;

    // �̵����
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

    // ����� ��Ʈ, baud rate (��� �ӵ�)
    private SerialPort serial;
    private string rcv_data = null;

    [SerializeField] private PortNumber portNumber = PortNumber.COM1;
    [SerializeField] private string baudRate = "9600";
    [SerializeField] public string BatNumber;



   

    public string nPort = "COM8";

    private float x;   // ���� ��   ���ʹϾ� �� �ޱ�
    private float y;
    private float z;
    private float w;

    private float Vx;  // �ӵ� ����  
    private float Vy;
    private float Vz;
    //public float encoder_value = 0f;



    Thread myThread;

    void Start()
    {
       


        // �ø��� ��Ʈ �ʱ�ȭ �ø��� ��� �������� �ʿ��� �ڵ�
        serial = new SerialPort(portNumber.ToString(), int.Parse(baudRate), Parity.None, 8, StopBits.One);
        //serial.Open();
        serial.Open();
        myThread = new Thread(new ThreadStart(GetData));
        myThread.Start();       // ��Ʈ�� ������ ���� ���۵�

        //serial.WriteTimeout = 10000;  
        for (int thisReading = 0; thisReading < numReadings; thisReading++)
        {
            readings[thisReading] = 0;   // ���簪�� �д� ������ 0���� �ʱ�ȭ
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
                    //Debug.Log("����");
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




        z = float.Parse(strListVal[0]);  // ���� ��
        y = float.Parse(strListVal[1]);
        x = float.Parse(strListVal[2]);
        w = float.Parse(strListVal[3]);  // ��Į�� ��

        Vx = float.Parse(strListVal[4]); // �ӵ� ����
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


    private void CalRotate(String nport)    // ahrx �� ��������
    {

        Test_Bat.transform.localRotation = new Quaternion(Moving_Avg_Filter(x), Moving_Avg_Filter(y), Moving_Avg_Filter(z), Moving_Avg_Filter(w)); // �̵� ��� ���� �迭 �Ἥ

    }


    void BatCollision(string str)
    {
        serial.Write(str);
    }


    private void OnApplicationQuit() // ���α׷� ����� �� ��Ʈ�� ������ �������
    {
        serial.Close();
        Debug.Log("����");
        myThread.Abort();
        myThread.Suspend();

    }
}
