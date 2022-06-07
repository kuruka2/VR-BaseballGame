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



    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonUp("Fire1"))
        {
            Shoot();
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
