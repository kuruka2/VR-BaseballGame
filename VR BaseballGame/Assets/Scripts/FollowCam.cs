using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour  // FollowCam_Ball
{
    public GameObject target;    // 오브젝트의 위치
    public float dist = 10f;    // 카메라와의 거리
    public float height = 5f;   // 높이
    public float smoothRotate = 5f; // 부드러운 회전을 위한 변수
    List<GameObject> BaseBallList = new List<GameObject>();

    private Transform tr;

     public void OnEnable()
    {

        tr = GetComponent<Transform>();
    }
    void LateUpdate()
    {
        //부드러운 회전을 위한 Mathf.LerpAngle
        //float cyrrYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y, smoothRotate * Time.deltaTime);  //(a,b,c) a부터 b까지 c시간동안 각도를 부드럽게 회전시킨다.회전시간을 조정하고 싶으면 smoothRotate 변수 조정

        //// 오일러 타입을 쿼터니언으로 바꾸기   //x,y,z 축을 차례로 회전하기 때문에 짐벌락이라는 회전이 멈추는 현상이 생기게 된다. 이를 해결하기 위한 쿼터니언으로 3개의 축을 한번에 회전시킴
        //// transform.rotation 함수는 quaternion.Euler를 이용해 오일러를 쿼터니언화하여 대입
        //Quaternion rot = Quaternion.Euler(0, cyrrYAngle, 0);

        //// 카메라 위치를 타겟 회전각도만큼 회전 후 dist만큼 띄우고, 높이를 올리기
        //tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);   // 공의 회전으로 인해 밑에 있는 코드만 씀

        
      //  tr.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z+20);

        // 타겟을 바라보게 하기

      //  tr.LookAt(target.transform);
    }
    GameObject BaseballList(GameObject BaseBall)
    {
        Debug.Log(BaseBall);
        target = BaseBall;
        return target;
    }
}