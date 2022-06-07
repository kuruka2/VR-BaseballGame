using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalShoot : MonoBehaviour
{

    [SerializeField] float speed = 10; // 야구공 속도 [m/s]  // 

    float cnt = 0;


    Angle_confirm Angle_cofirm_on_Off;
    Destination_Prediction Destination_Prediction_on_off;

    Vector3 destination1; // 거리공식에 쓰이는 위치
    Vector3 destination2;
    Vector3 startPosition;

    Vector3 Hit_location;

    bool hit_capsule = false;
    public float angle1;    //각도
    public float destination; // 최종거리
    float velo; // 공이 배트에 맞고 초기속도
    public float angle;

    bool paul = false;  // 파울 변수
    bool timeset = false;   // 공이 배트에 맞았을 경우

    float GetAngle(Vector3 vS, Vector3 vE)   // -180  ~ 180    y축 각도 조절 // 고치기 
    {

        //Vector3 vE = gameObject.transform.position;

        Vector3 v = vE - vS;

        float getAngle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg; // Atan2 탄젠트 공식,rad2deg 라디안을 degree로 바꿈


        return getAngle;

    }
    public float CalculateAngle()   // -360 ~ 360   
    {
        float a;
        
        Vector3 pos = gameObject.transform.position;
        Vector3 k = new Vector3(0.1f, 0.13f, 0.4f);

        if (Quaternion.FromToRotation(-Vector3.forward, k - pos).eulerAngles.y < 180)       
            a = Quaternion.FromToRotation(Vector3.forward, k - pos).eulerAngles.y;  
        
        else
            a = Quaternion.FromToRotation(-Vector3.forward, k - pos).eulerAngles.y;


        return a;
        // 쿼터니언 스칼라값을 정할 수 있음,오일러각 각도를 나타내줌
        //fromToRotation(중심축,회전하고싶은 방향벡터)
    }

    private void OnDestroy()
    {
        Angle_cofirm_on_Off.enabled = false;
        Destination_Prediction_on_off.enabled = false;
    }

    void Start()
    {
        Angle_cofirm_on_Off = GameObject.Find("Destination").GetComponent<Angle_confirm>();
        Destination_Prediction_on_off = GameObject.Find("Destination").GetComponent<Destination_Prediction>();
        startPosition = new Vector3(-0.3f, 0.5f, 0);

        var velocity = speed * transform.forward;
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddForce(velocity, ForceMode.VelocityChange); // 공이 앞쪽으로 나가는 코드

    }
    public void OnCollisionEnter(Collision other)
    {



        if (other.gameObject.name == "BatFollower1(Clone)")
        {
            GameObject bat1 = GameObject.Find("BatFollower1(Clone)");
            float a = bat1.GetComponent<BatCapsuleFollower>().getVelocity();
            var velocity = speed * transform.position * 1.5f * (a / 10) / 15;     // 야구공 스피트와 휘두르는 힘 배트위치에너지 힘
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(velocity, ForceMode.VelocityChange);
            paul = true;    // 파울체크
            timeset = true;    // 각도와 위치구하는 코드
            

        }

        if (other.gameObject.name == "BatFollower2(Clone)")       // 배트에 공이 맞는 위치에 따라 다른 힘
        {
            GameObject bat2 = GameObject.Find("BatFollower2(Clone)");
            float b = bat2.GetComponent<BatCapsuleFollower>().getVelocity();
            var velocity = speed * transform.position * 1.2f * (b / 10) / 15;
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(velocity, ForceMode.VelocityChange);
            paul = true;
            timeset = true;
        }

        if (other.gameObject.name == "BatFollower3(Clone)")
        {
            GameObject bat3 = GameObject.Find("BatFollower3(Clone)");
            float c = bat3.GetComponent<BatCapsuleFollower>().getVelocity();

            var velocity = speed * transform.position * 1.1f * (c / 10) / 15; // 초기속도
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(velocity, ForceMode.VelocityChange);
            paul = true;
            timeset = true;
        }


        if (other.gameObject.name == "Strike_Zone")    //스트라이크 존에 닿으면 사라짐
        {
            Destroy(gameObject);

        }

        if (other.gameObject.tag == "Ground")
        {

            //Debug.Log("도착지점" + gameObject.transform.position + "도착지점 범위 : " + Vector3.Magnitude(gameObject.transform.position));
            Destroy(gameObject);    // 일시적


        }


    }
    public void FixedUpdate()
    {

        if (timeset == true)
        {

            cnt += Time.fixedDeltaTime;  // 1프레임 0.02초
            if (0.00f < cnt && cnt < 0.03f)
            {
                destination1 = gameObject.transform.position;


            }
            if (0.05f < cnt && cnt < 0.08f)
            {
                destination2 = gameObject.transform.position;

            }


            if (0.1f < cnt && cnt < 0.13f)  // y축 각도의 오차를 줄이기 위해
            {

                angle = GetAngle(destination1, destination2);

            }
            if (2f < cnt && cnt < 2.02f)
            {




                velo = Vector3.Distance(destination2, destination1) / 0.04f;
                Debug.Log("속도" + velo);


                destination = Mathf.Pow(velo, 2) * Mathf.Sin((2 * angle) * Mathf.Deg2Rad) / 9.8f;   // 범위 각도 라디안으로


                Debug.Log("범위" + destination + "  y축 각도 : " + angle);
                angle1 = CalculateAngle();

                Angle_cofirm_on_Off.enabled = true;
                Destination_Prediction_on_off.enabled = true;
              

                Debug.Log("x z 축 각도" + CalculateAngle());
                Hit_location = gameObject.transform.forward;

                /* Debug.Log("Dest" + Dest + Vector3.Magnitude(posi) + rotate); */   // x
            }



        }

        Vector3 drawPoint = Hit_location + gameObject.transform.position;

        Debug.DrawLine(Hit_location, drawPoint, Color.red);

    }


}
