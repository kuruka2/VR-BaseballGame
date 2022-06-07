using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitter_Camera : MonoBehaviour
{
    float mx = 0;
    float my = 0;
    float speed = 200f;

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");    // 마우스 입력받기
        float MouseY = Input.GetAxis("Mouse Y");

        // 회전 값 변수에 마우스 입력 값만큼 미리 누적시킨다.
        mx = MouseX * speed * Time.deltaTime;
        my = MouseY * speed * Time.deltaTime;

        // y축 회전 값을 -90 - 90도 사이로 제한함
        my = Mathf.Clamp(my, -90f, 90f);
        //  transform.rotation.setAxisAngle(00, 0, mx);
        //  transform.posaition.x + mx,my

        // 회전 방향으로 물체 회전
        transform.eulerAngles += new Vector3(-my, mx, 0);
    }
}


        // 마우스로 입력받기
//float MouseX = Input.GetAxis("Mouse X");    // 마우스 입력받기
//float MouseY = Input.GetAxis("Mouse Y");

//// 회전 값 변수에 마우스 입력 값만큼 미리 누적시킨다.
//mx = MouseX * speed * Time.deltaTime;
//my = MouseY * speed * Time.deltaTime;

//// y축 회전 값을 -90 - 90도 사이로 제한함
//my = Mathf.Clamp(my, -90f, 90f);
////  transform.rotation.setAxisAngle(00, 0, mx);
////  transform.posaition.x + mx,my

//// 회전 방향으로 물체 회전
//transform.eulerAngles += new Vector3(-my, mx, 0);
//// Debug.Log(mx + " " + my);