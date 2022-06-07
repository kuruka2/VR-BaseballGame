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

public class Port_ex1 : MonoBehaviour
{

    public GameObject Test_Bat;
    public Bat1 Test_Bat_1;   // 캡슐 1, 2, 3
    public Bat2 Test_Bat_2;
    public Bat3 Test_Bat_3;
    public List<GameObject> FoundObjects;
    public GameObject Bat_hit_location;
    public GameObject Baseballtest;


    public enum PortNumber
    {
        COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, COM11, COM12
    }

    // 연결된 포트, baud rate (통신 속도)
    private SerialPort serial;
    private string rcv_data = null;

    [SerializeField] private PortNumber portNumber;
    [SerializeField] private string baudRate = "115200";

    public string nPort;

    private float x;   // 벡터 값   쿼터니언 값 받기
    private float y;
    private float z;
    private float w;

    private float cx;
    private float cy;
    private float cz;
    private float cw;

    private float Vx;  // 속도 벡터  
    private float Vy;
    private float Vz;

    public GameObject Pitcher;
    private Animator animator;
    bool fuck=false;
    int test=0;

    // test 
    public Camera camera;

    private Thread myThread;
    private Queue<GameObject> queue = new Queue<GameObject>();

    void Start()
    {

        // 시리얼 포트 초기화 시리얼 통신 과정에서 필요한 코드
        serial = new SerialPort(portNumber.ToString(), int.Parse(baudRate), Parity.None, 8, StopBits.One);
        //serial.Open();
        serial.Open();
        myThread = new Thread(new ThreadStart(GetData));    // 통신 데이터 처리를 하기 위해 스레드 사용.
        myThread.Start();       // 포트가 닫혀도 값이 전송됨

        //serial.WriteTimeout = 10000;  
        animator = Pitcher.GetComponent<Animator>();

    }
    void FixedUpdate()
    {

        CalRotate(nPort);
        // 안되는 원인 fixedUpdate가 메인스레드 데이터 받는 속도를 못 따라감.

        if (rcv_data.Contains("!") == true)
        {
            animator.SetBool("Throwing", true);
            StartCoroutine("pitch");
        }
        if (test==1)
        {              
            Debug.Log("1");
            test = 0;
        }
    }
    IEnumerator pitch()
    {
            yield return new WaitForSeconds(1.69f);
            Thread.Sleep(10);
            lock (Instantiate(Baseballtest, gameObject.transform.position, gameObject.transform.rotation));

        test =1;
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
                    rcv_data = serial.ReadLine();
                    testseparate(rcv_data);     // 데이터 쪼개기
             
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

        if (((z < 1f) && (z > -1f) && (z != 0f)) && //x,y,z,w,의 값이 쿼터니온 범위를 벗어나 튈 때 예외처리
         ((x < 1f) && (x > -1f) && (x != 0f)) &&
         ((y < 1f) && (y > -1f) && (y != 0f)) &&
         ((w < 1f) && (w > -1f) && (w != 0f)))
        {
            cz = z;
            cy = y;
            cx = x;
            cw = w;
        }

        if (Vz > 0.5) // 각속도로 스트라이크
        {

        }

        //Debug.Log("(x, y, z, w, Vx, Vy, Vz) = (" + string.Format("{0:0.##}", x) + ", "
        //                                  + string.Format("{0:0.##}", y) + ", "
        //                                  + string.Format("{0:0.##}", z) + ", "
        //                                  + string.Format("{0:0.##}", w) + ", "
        //                                  + string.Format("{0:0.##}", Vx) + ", "
        //                                  + string.Format("{0:0.##}", Vy) + ", "
        //                                  + string.Format("{0:0.##}", Vz) + ", ");

    }

    private void CalRotate(String nport)    // ahrx 값 가져오기
    {
        //Test_Bat.transform.rotation = Quaternion.Euler(Moving_Avg_Filter(z*100), Moving_Avg_Filter(y*100), Moving_Avg_Filter(x*100)); // 오일러  roll, pitch, yaw
        Test_Bat.transform.rotation = new Quaternion(-cx * 10, cz * 10, cy * 10, cw * 10); // 쿼터니언 
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
    }

}
