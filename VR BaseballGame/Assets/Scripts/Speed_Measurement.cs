using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Text 자료형을 쓰려고

public class Speed_Measurement : MonoBehaviour
{
    private Vector3 m_LastPosition;
    public float m_Speed;
    //public Text m_MeterPerSecond, m_KilometersPerHour;   // 속도 알려주는 텍스트   나중에 전광판에 넣을것들

    void FixedUpdate()
    {
        //m_Speed = GetSpeed();
        //Debug.Log(m_Speed);
        //m_MeterPerSecond.text = string.Format("{0:00.00} m/s", m_Speed);
        //m_KilometersPerHour.text = string.Format("{0:00.00} km/h", m_Speed * 3.6f);
    }

    float GetSpeed()
    {
        float speed = (((transform.position - m_LastPosition).magnitude) / Time.deltaTime); // 변위를 구해서 속도
        m_LastPosition = transform.position;

        return speed;
    }

}
