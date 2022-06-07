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

public class Port_ex1 : MonoBehaviour
{

    public GameObject Test_Bat;
    public Bat1 Test_Bat_1;   // ĸ�� 1, 2, 3
    public Bat2 Test_Bat_2;
    public Bat3 Test_Bat_3;
    public List<GameObject> FoundObjects;
    public GameObject Bat_hit_location;
    public GameObject Baseballtest;


    public enum PortNumber
    {
        COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, COM11, COM12
    }

    // ����� ��Ʈ, baud rate (��� �ӵ�)
    private SerialPort serial;
    private string rcv_data = null;

    [SerializeField] private PortNumber portNumber;
    [SerializeField] private string baudRate = "115200";

    public string nPort;

    private float x;   // ���� ��   ���ʹϾ� �� �ޱ�
    private float y;
    private float z;
    private float w;

    private float cx;
    private float cy;
    private float cz;
    private float cw;

    private float Vx;  // �ӵ� ����  
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

        // �ø��� ��Ʈ �ʱ�ȭ �ø��� ��� �������� �ʿ��� �ڵ�
        serial = new SerialPort(portNumber.ToString(), int.Parse(baudRate), Parity.None, 8, StopBits.One);
        //serial.Open();
        serial.Open();
        myThread = new Thread(new ThreadStart(GetData));    // ��� ������ ó���� �ϱ� ���� ������ ���.
        myThread.Start();       // ��Ʈ�� ������ ���� ���۵�

        //serial.WriteTimeout = 10000;  
        animator = Pitcher.GetComponent<Animator>();

    }
    void FixedUpdate()
    {

        CalRotate(nPort);
        // �ȵǴ� ���� fixedUpdate�� ���ν����� ������ �޴� �ӵ��� �� ����.

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
                    testseparate(rcv_data);     // ������ �ɰ���
             
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

        if (((z < 1f) && (z > -1f) && (z != 0f)) && //x,y,z,w,�� ���� ���ʹϿ� ������ ��� ƥ �� ����ó��
         ((x < 1f) && (x > -1f) && (x != 0f)) &&
         ((y < 1f) && (y > -1f) && (y != 0f)) &&
         ((w < 1f) && (w > -1f) && (w != 0f)))
        {
            cz = z;
            cy = y;
            cx = x;
            cw = w;
        }

        if (Vz > 0.5) // ���ӵ��� ��Ʈ����ũ
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

    private void CalRotate(String nport)    // ahrx �� ��������
    {
        //Test_Bat.transform.rotation = Quaternion.Euler(Moving_Avg_Filter(z*100), Moving_Avg_Filter(y*100), Moving_Avg_Filter(x*100)); // ���Ϸ�  roll, pitch, yaw
        Test_Bat.transform.rotation = new Quaternion(-cx * 10, cz * 10, cy * 10, cw * 10); // ���ʹϾ� 
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
    }

}
