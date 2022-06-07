using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defending_Throw : MonoBehaviour
{

    public GameObject Baseball;
   public Follow_Ball follow_Ball;
    float distance;
    public void FixedUpdate() // 수비수가 공을 잡으면 어떤 지점에 공을 다시 던지는 코드
    {

        if(follow_Ball.enabled == true)
        {
            Baseball= GameObject.Find("CricketBall(Clone)");    // 임시방편
            distance = Vector3.Distance(gameObject.transform.position, Baseball.transform.position);
            if (distance <= 20)
            {
                Debug.Log("catch"); // 수비수가 공을 잡고 던짐
            }
          
        }


        //float distance = Vector3.Distance(gameObject.transform.position, Baseball.transform.position);
        //Debug.Log(Baseball.transform.position);
        //if(distance <= 10f)
        //{
        //    Debug.Log("catch");
        //}


    }



}
