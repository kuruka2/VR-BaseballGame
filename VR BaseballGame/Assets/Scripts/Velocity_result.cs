using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity_result : MonoBehaviour
{
    //초기 속도, 각도,중력,

    public Vector3 from;
    Vector3 Dest;
    
    public float CalculateAngle(Vector3 from, Vector3 to)   // -360 ~ 360
    {
        return Quaternion.FromToRotation(-Vector3.forward, from - to).eulerAngles.y; // 쿼터니언 스칼라값을 정할 수 있음,오일러각 각도를 나타내줌
         //fromToRotation(중심축,회전하고싶은 방향벡터)
    }

    float GetAngle(Vector3 vS, Vector3 vE)   // -180  ~ 180
    {
      
        Vector3 v = vE - vS;
       
         
        return Mathf.Abs(Mathf.Atan2(v.y, v.x)) * Mathf.Rad2Deg;   // Atan2 탄젠트 공식,rad2deg 라디안을 degree로 바꿈
    }
    public void FixedUpdate()
    {
        //Debug.Log(CalculateAngle(from, gameObject.transform.position));
        //Debug.Log(GetAngle(from, gameObject.transform.position));

    }
    void Start()
    {
        Vector3 posi;
        posi = new Vector3(11.5f, 11.5f, 3.4f);
        Vector3 Distance = Vector3.forward * 100f;  // Vector3.forward => x z 축 기준으로 하는 각도로 바꿔야됌 , 100f 거리
        Quaternion rotate = Quaternion.Euler(0, 61f, 0);   //회전할 각도
        Vector3 Target = rotate * Distance; //원점을 기준으로 거리와 각도를 연산한 후, 벡터
        Vector3 Dest = gameObject.transform.position + Target;  // 오브젝트에서 해당 거리와 각도만큼 이동한 곳의 좌표

       

        //Debug.Log("Dest"+Dest);
    }
}
