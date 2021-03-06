using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class BaseBall1 : MonoBehaviour
{

    public GameObject baseball_prefabs;    // baseball 오브젝트 배열 넣기
    [SerializeField] Transform postionPrefab;
    public Camera camera;
    public GameObject Destination;
    Quaternion RanRotation;

    public
    List<GameObject> BaseBallList = new List<GameObject>();     // 랜덤으로 보낼 공 리스트화


    void Start()
    {


    }
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            float ranX = Random.Range(-0.01f, -0.03f);  // 카메라 rotation 난수 설정
            float ranY = Random.Range(0.022f, -0.01f);
            float ranZ = Random.Range(-0.022f, 0);

            gameObject.transform.rotation = new Quaternion(ranX, ranY, ranZ, 1);  // 카메라 회전 난수로 설정해서 공 보내기

            Invoke("Shoot", 1.79f);
        }

    }

    void Shoot()    // Follow cam baseball 설정 // 나중에 portopen에서 설정해야됌
    {
        Instantiate(baseball_prefabs, postionPrefab.position, RanRotation); 
    }

}
