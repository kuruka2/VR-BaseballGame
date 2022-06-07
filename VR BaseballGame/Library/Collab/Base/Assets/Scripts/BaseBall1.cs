using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class BaseBall1 : MonoBehaviour
{
    [SerializeField] GameObject baseballPrefab;
    [SerializeField] GameObject baseball2Prefab;
    [SerializeField] GameObject baseball3Prefab;
    [SerializeField] GameObject baseball4Prefab;
    [SerializeField] GameObject baseball5Prefab;
    [SerializeField] Transform postionPrefab;

   //public enum Portnumber
   // {
   //     COM1,COM2,COM3,COM4,COM5
   // }

   // [SerializeField] private Portnumber portNumber = Portnumber.COM1; // 포트넘버
   // [SerializeField] private string baudRate = "9600";
   // private SerialPort serial;

    void Start()
    {
        //serial = new SerialPort(portNumber.ToString(), int.Parse(baudRate), Parity.None, 8, StopBits.One); // 나중에
        //serial.Open();
        //serial.ReadTimeout = 1000;
           
    }

    // Update is called once per frame
    void Update()
    {
        //if (serial.IsOpen) // 시리얼 포트에 연결되었으면
        //{
        //    try
        //    {
        //        //serial.ReadChar();
        //        //Debug.Log(serial.BytesToRead);
        //        //Debug.Log(serial.ReadExisting());
        //        //Shoot(int.Parse(serial.ReadExisting()));

        //    }

        //    catch (System.TimeoutException e)
        //    {
        //        Debug.Log(e);
        //        throw;
        //    }

        //}
        //else if (!serial.IsOpen)
        //{
        //    serial.Open();
        //}


        if (Input.GetButtonUp("Fire1"))
        {
            Invoke("Shoot", 1.79f);
        }

        if (Input.GetButtonUp("Fire2"))
        {

            Courve_Shoot();

        }
        if (Input.GetKeyDown("k"))
        {
            Debug.Log("FokeShoot");
            Foke_Shoot();

        }
        if (Input.GetKeyDown("l"))
        {
            Debug.Log("ScrewShoot");
            Screw_Shoot();

        }
        if (Input.GetKeyDown("o"))
        {
            Debug.Log("EnphusShoot");
            Eephus_Shoot();

        }


    }

    void Close()
    {
        //serial.Close();
    }

    void Shoot()
    {
        Instantiate(baseballPrefab, postionPrefab.position, postionPrefab.rotation);
    }
    //void Shoot(int num) // 버튼1이 들어오면 공이 나감
    //{
      
    //    if (num == 3)
    //    {
    //        Debug.Log("2");
    //        // 프리팹을 바탕으로 씬 상에서 공을 생성
    //        Instantiate(baseballPrefab, postionPrefab.position, postionPrefab.rotation);
    //    }
    //}
    void Courve_Shoot()
    {
        // 프리팹을 바탕으로 씬 상에서 공을 생성
        Instantiate(baseball2Prefab, postionPrefab.position, postionPrefab.rotation);
    }
    void Foke_Shoot()
    {
        // 프리팹을 바탕으로 씬 상에서 공을 생성
        Instantiate(baseball3Prefab, postionPrefab.position, postionPrefab.rotation);
    }
    void Screw_Shoot()
    {
        // 프리팹을 바탕으로 씬 상에서 공을 생성
        Instantiate(baseball4Prefab, postionPrefab.position, postionPrefab.rotation);
    }
    void Eephus_Shoot()
    {
        // 프리팹을 바탕으로 씬 상에서 공을 생성
        Instantiate(baseball5Prefab, postionPrefab.position, postionPrefab.rotation);
    }
}
