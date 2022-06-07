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
        float MouseX = Input.GetAxis("Mouse X");    // ���콺 �Է¹ޱ�
        float MouseY = Input.GetAxis("Mouse Y");

        // ȸ�� �� ������ ���콺 �Է� ����ŭ �̸� ������Ų��.
        mx = MouseX * speed * Time.deltaTime;
        my = MouseY * speed * Time.deltaTime;

        // y�� ȸ�� ���� -90 - 90�� ���̷� ������
        my = Mathf.Clamp(my, -90f, 90f);
        //  transform.rotation.setAxisAngle(00, 0, mx);
        //  transform.posaition.x + mx,my

        // ȸ�� �������� ��ü ȸ��
        transform.eulerAngles += new Vector3(-my, mx, 0);
    }
}


        // ���콺�� �Է¹ޱ�
//float MouseX = Input.GetAxis("Mouse X");    // ���콺 �Է¹ޱ�
//float MouseY = Input.GetAxis("Mouse Y");

//// ȸ�� �� ������ ���콺 �Է� ����ŭ �̸� ������Ų��.
//mx = MouseX * speed * Time.deltaTime;
//my = MouseY * speed * Time.deltaTime;

//// y�� ȸ�� ���� -90 - 90�� ���̷� ������
//my = Mathf.Clamp(my, -90f, 90f);
////  transform.rotation.setAxisAngle(00, 0, mx);
////  transform.posaition.x + mx,my

//// ȸ�� �������� ��ü ȸ��
//transform.eulerAngles += new Vector3(-my, mx, 0);
//// Debug.Log(mx + " " + my);