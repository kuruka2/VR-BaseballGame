using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle_confirm : MonoBehaviour
{

    NomalShoot velo;

    public List<GameObject> FoundObjects;
    public GameObject OutFielder;
    Follow_Ball oufielder;
    Follow_Ball oufielder1;
    Follow_Ball oufielder2;



    float Angle1;
    float Destination;


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



        Angle1 = GameObject.Find("BaseBall(Clone)").GetComponent<NomalShoot>().angle1;
        Destination = GameObject.Find("BaseBall(Clone)").GetComponent<NomalShoot>().destination;

        Vector3 vecY = new Vector3(0, Angle1, 0);

        Vector3 Dist = -Vector3.forward * Destination;  // Vector3.forward => x z 축 기준으로 하는 각도로 바꿔야됌 , 100f 거리// 래이캐스트 없이 구하는 법
        Quaternion rotate = Quaternion.Euler(0, Angle1, 0);   //회전할 각도
        Vector3 Des = rotate * Dist; //원점을 기준으로 거리와 각도를 연산한 후, 벡터
        Target.transform.position = gameObject.transform.position + Des;  // 오브젝트에서 해당 거리와 각도만큼 이동한 곳의 좌표

        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("BallFollower"));         // 공과 가장 가까운 외야수가 공을 잡으러가는 코드
        shortDis = Vector3.Distance(Target.transform.position, FoundObjects[0].transform.position);

        OutFielder = FoundObjects[0];
        //Debug.Log(ConvertAngleToVector(Angle1));
        Debug.Log(Target.transform.position);

        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(Target.transform.position, found.transform.position);

            if (Distance < shortDis)
            {
                OutFielder = found;

                shortDis = Distance;
            }
        }
        //Debug.Log(OutFielder);
        OutFielder.GetComponent<Follow_Ball>().enabled = true;


        //Debug.Log("예측지점 : "+ConvertAngleToVector(Angle1));

    }
    private void OnDisable()
    {
        OutFielder.GetComponent<Follow_Ball>().enabled = false;
        Target.transform.position = new Vector3(0, 0, 0);
    }
    void FixedUpdate()
    {


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
