 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Rigidbody ball;
    public Transform target;
    public GameObject GameObject;
    public float h = 30;       // 최고점의 높이
    public float gravity = -9.8f;

    public bool debugpath;


   void Start()
    {
        ball.useGravity = false;
        GameObject = GameObject.Find("ball");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Launch();
            

        }
       
            DrawPath();
        
    }

    void Launch()
    {
        Physics.gravity = Vector3.up * gravity;        // 중력 적용
        ball.useGravity = true;
        ball.velocity = CalculateLaunchLaunchData().initialVelocity;    //  초기 속도 바꾸기

    }
    LaunchData CalculateLaunchLaunchData()      // 포물선 방정식
    {
        float displacementY = target.position.y - ball.position.y;  // 타겟과 공 사이의 y 거리   // 타겟의 y 값은 0으로 설정  // 바닥과 배트의 거리만 측정
        Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);  // 수평 변위
        float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);  //  루트(-2h/g)+루트(2(Py-h)/g))  => s =vt -at^2/2
        // h의 값은 초기 타구 y값 velocity로
        
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);  // 높이 벡터 루트(-2gh)  => v^2 = u^2+2as
        Vector3 velocityXZ = displacementXZ / time;     // 수평 방향 속도

        return new LaunchData (velocityXZ + velocityY *-Mathf.Sign(gravity),time);

    }
    

    void DrawPath()
    {
        LaunchData launchData = CalculateLaunchLaunchData();
        Vector3 previousDrawPoint = ball.position;

        int resolution = 30;
        for (int i = 1; i <= resolution; i++)
        {
            float simulationTime = i / (float)resolution * launchData.timeToTarget;  // t 비행시간
            Vector3 displacement = launchData.initialVelocity * simulationTime +Vector3.up* gravity * simulationTime*simulationTime / 2f;
            // s= vt + (at)^2/2     // a =gravity

            Vector3 drawPoint = ball.position + displacement;       // ?
            Debug.DrawLine(previousDrawPoint, drawPoint, Color.red);
            previousDrawPoint = drawPoint;
            
        }
    }

    struct LaunchData   // 다시공부
    {
        public readonly Vector3 initialVelocity;    // readonly const와 비슷 
        public readonly float timeToTarget;         // 타겟까지 가는 시간 

        public LaunchData (Vector3 initialVelocity , float timeToTarget)
        {
            this.initialVelocity = initialVelocity; // 초기 속도 바꾸기
            this.timeToTarget = timeToTarget;
            //Debug.Log(initialVelocity+" 초기 "+timeToTarget);
        }

    }








}
