using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle_confirm : MonoBehaviour
{

    NomalShoot velo;

    public List<GameObject> FoundObjects;
    public GameObject OutFielder;
    public GameObject InsideFielder;

    Follow_Ball oufielder;
    Follow_Ball oufielder1;
    Follow_Ball oufielder2;

    Follow_Ball infielder;
    Follow_Ball infielder1;
    Follow_Ball infielder2;


    float Angle1;
    float Destination;

    float Destination1;
    

    public Transform Target;
    public float shortDis;
         
    
    private Vector3 ConvertAngleToVector(float deg) // 삼각비 이용해 좌표 구하기 (거리와 각도 이용해)  
    {
        var rad = deg * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(rad) * Destination, 0, Mathf.Cos(rad) * Destination);    
    }


    // Start is called before the first frame update
    void OnEnable()
    {

        oufielder = GameObject.Find("OutsideDefender1").GetComponent<Follow_Ball>();
        oufielder1 = GameObject.Find("OutsideDefender2").GetComponent<Follow_Ball>();
        oufielder2 = GameObject.Find("OutsideDefender3").GetComponent<Follow_Ball>();
        infielder = GameObject.Find("InfielderDefender1").GetComponent<Follow_Ball>();
        infielder1 = GameObject.Find("InfielderDefender2").GetComponent<Follow_Ball>();
        infielder2 = GameObject.Find("InfielderDefender3").GetComponent<Follow_Ball>();

        Angle1 = GameObject.FindWithTag("BaseBall").GetComponent<NomalShoot>().angle1;
        Destination = GameObject.FindWithTag("BaseBall").GetComponent<NomalShoot>().destination;

        Target.transform.position = ConvertAngleToVector(Angle1);

        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("BallFollower"));         // 공과 가장 가까운 외야수가 공을 잡으러가는 코드
        shortDis = Vector3.Distance(Target.transform.position, FoundObjects[0].transform.position);

        OutFielder = FoundObjects[0];
        InsideFielder = FoundObjects[0];

        //Debug.Log(ConvertAngleToVector(Angle1));

        //Debug.Log(Target.transform.position);
        

        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(Target.transform.position, found.transform.position);

            if (Distance < shortDis)        
            {
                InsideFielder = found;
                OutFielder = found;
                
                shortDis = Distance;
            }
        }
      
       OutFielder.GetComponent<Follow_Ball>().enabled=true;
       InsideFielder.GetComponent<Follow_Ball>().enabled = true;


        //Debug.Log("예측지점 : "+ConvertAngleToVector(Angle1));

    }
    private void OnDisable()
    {
        InsideFielder.GetComponent<Follow_Ball>().enabled = false;
        OutFielder.GetComponent<Follow_Ball>().enabled = false;
        Target.transform.position = new Vector3(0, 0, 0);
    }
     void FixedUpdate()
    {
        Debug.DrawLine(new Vector3(0, 0, 0), Target.transform.position, Color.blue);
    }

    //float[] data = { Vector3.Distance(a,Target.transform.position), Vector3.Distance(b, Target.transform.position), Vector3.Distance(c, Target.transform.position) };

    //float mindis = 0;

    //for(int i = 0; i < data.Length; i++)
    //{
    //    if (mindis > data[i])
    //    {
    //        mindis = data[i];
    //    }
    //}
}
