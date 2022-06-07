using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Port : MonoBehaviour
{

    public enum PortNumber
    {
        COM1, COM2, COM3, COM4, COM5
    }

    // 연결된 포트, baud rate (통신 속도)
    private SerialPort serial;

    [SerializeField] private PortNumber portNumber = PortNumber.COM4;   // 포트 넘버
    [SerializeField] private string baudRate = "9600";






    // Update is called once per frame
    void Start()
    {
        serial = new SerialPort(portNumber.ToString(), int.Parse(baudRate), Parity.None, 8, StopBits.One);
        serial.Open();
        //serial.ReadTimeout = 5;

    }

    void Update()
    {
        // 시리얼 포트에 연결되었으면
        if (serial.IsOpen)
        {
           
            try
            {
                ex(serial.ReadChar());
            }
            catch (System.TimeoutException e)
            {
                Debug.Log(e);
                throw;
            }
            Debug.Log("연결");
        }
        else if (!serial.IsOpen)
        {
            serial.Open();
        }
    }
    void ex(int num)
    {
        if(num == 1)
        {
            Debug.Log("버튼 1");
        }
        if (num == 2)
        {
            Debug.Log("버튼 2");
        }
    }

}

