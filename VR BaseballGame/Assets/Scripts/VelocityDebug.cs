using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDebug : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 20f;
    

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color= ColorForVelocity();    
    }

    Color ColorForVelocity()
    {
        float velocity = GetComponent<Rigidbody>().velocity.magnitude;  // 해당 물체가 이동할 때마다 얼마나 이동하는지 계산

        return Color.Lerp(Color.green, Color.red, velocity / maxVelocity);  // 배트가 느리면 녹색 빠르면 적색
    }
}
