using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination_Prediction : MonoBehaviour
{
   Angle_confirm ON_OFF;

    float Angle1;
    float Cnt = 0;
    public Transform Target;
    float Angle2;
    float Destination;
    float Destination1;

    private Transform target;
    //float targettvalue;

    LayerMask Laymask;

    RaycastHit hit;

    private Vector3 ConvertAngleToVector(float deg)
    {
        var rad = deg * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad)*Destination, 0, Mathf.Sin(rad)*Destination);      // 레이캐스트보다 오차가 심함.....
    }

    private Vector3 ConAtV(float degree)
    {
        var radian = degree * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian) * Destination, 0, Mathf.Tan(radian) * Destination1);
    }

    public void OnEnable()
    {
        Angle2 = GameObject.Find("BaseBall(Clone)").GetComponent<NomalShoot>().angle;
        Angle1 = GameObject.Find("BaseBall(Clone)").GetComponent<NomalShoot>().angle1;
        Destination = GameObject.Find("BaseBall(Clone)").GetComponent<NomalShoot>().destination;
        target = GameObject.Find("target").GetComponent<FollowTarget>().followtarget;

        Destination1 = GameObject.Find("BaseBall(Clone)").GetComponent<NomalShoot>().testdestination;

        /*transform.Rotate(new Vector3(0, Angle1, 0));*/ //y축 각도 바꿔야됌 -> Calculateangle   
        gameObject.transform.rotation = Quaternion.Euler(0, Angle1, 0);
    }

    public void OnDisable()
    {

        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); // 비활성화 될때, 각도 0,0,0
         // 비활성화 될때, 각도 다시 바꿈 

    }

    // Update is called once per frame
  void FixedUpdate()
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * Destination /*각도 * 범위 */, Color.blue);

        //Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * Destination1, Color.black);

       // Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * targettvalue, Color.green);
        //if ((Physics.Raycast(gameObject.transform.position, gameObject.transform.forward * Destination, out hit, Destination, Laymask)))     // 래이캐스트 시작지점과 충돌지점이 같은 콜라이더면 호출안됨
        //    {

        //        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * Destination /*각도 * 범위 */, Color.black);
        //        Debug.Log(hit.point + "맞았다 " + hit.transform);

        //        Target.transform.position = hit.point;
        //    }
    }
}



 
        //Vector3 Distance = Vector3.forward * Destination;  // Vector3.forward => x z 축 기준으로 하는 각도로 바꿔야됌 , 100f 거리// 래이캐스트 없이 구하는 법
        //Quaternion rotate = Quaternion.Euler(0, 0, 0);   //회전할 각도
        //Vector3 Target = rotate * Distance; //원점을 기준으로 거리와 각도를 연산한 후, 벡터
        // Dest = gameObject.transform.position + Target;  // 오브젝트에서 해당 거리와 각도만큼 이동한 곳의 좌표



