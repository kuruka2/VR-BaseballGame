using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run2FirstBase : MonoBehaviour
{
    Vector3 FirstBase = new Vector3(-38.36f,0,-38.44f); // 1루

    private Animator animator; // 애니메이터
    public GameObject OnBaseHitter; // 출루타자

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, FirstBase, 0.025f); // 1루로 달림
        animator.SetBool("OnBase", true); // 달리기 모션 키고 

        if (gameObject.transform.position == FirstBase) // 1루에 도착하면 달리기 모션끔
        {
            animator.SetBool("OnBase", false); // 달리기모션 끄고
            gameObject.GetComponent<Run2FirstBase>().enabled = false; // 달리기 스크립트 끄고
            gameObject.transform.localEulerAngles = new Vector3(0, 136f, 0); //방향 2루로
        }
    }
}
