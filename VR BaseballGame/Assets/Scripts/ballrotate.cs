
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballrotate : MonoBehaviour
{

    float speed = 20f;            //공 회전 속도

    float rotate_x = 0f;             //x 축으로 회전함
    // Update is called once per frame
    void Update()
    {
        rotate_x += speed;                                          //x축에 값을 더함
        transform.rotation = Quaternion.Euler(rotate_x, 0f, 0f); // 더해진 x축으로 계속해서 회전
    }
}
