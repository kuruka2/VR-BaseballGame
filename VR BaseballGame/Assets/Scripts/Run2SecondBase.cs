using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run2SecondBase : MonoBehaviour
{
    Vector3 FirstBase = new Vector3(-38.36f, 0, -38.44f); // 1루
    Vector3 SecondBase = new Vector3(-0.06f,0,-77.3f); // 2루

    private Animator animator; // 애니메이터 
    public GameObject OnBaseHitter; // 출루타자

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.B))
        {
            gameObject.transform.localEulerAngles = new Vector3(0,-34f, 0); //방향 2루로
            transform.position = Vector3.MoveTowards(transform.position, FirstBase, 0.066f);
            animator.SetBool("OnBase", true);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, SecondBase, 0.025f); // 1루로 달림
            animator.SetBool("OnBase", true); // 달리기 모션 키고 

            if (gameObject.transform.position == SecondBase) // 1루에 도착하면 달리기 모션끔
            {
                animator.SetBool("OnBase", false); // 달리기모션 끄고
                gameObject.GetComponent<Run2SecondBase>().enabled = false;
                gameObject.transform.localEulerAngles = new Vector3(0, 413f, 0);
            }

            if (gameObject.transform.position == FirstBase) // 1루에 도착하면 달리기 모션끔
            {
                animator.SetBool("OnBase", false); // 달리기모션 끄고
                gameObject.GetComponent<Run2SecondBase>().enabled = false;
                gameObject.transform.localEulerAngles = new Vector3(0, 136f, 0);
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position, SecondBase, 0.066f); // 1루로 달림
        //animator.SetBool("OnBase", true); // 달리기 모션 키고 

        //if (gameObject.transform.position == SecondBase) // 1루에 도착하면 달리기 모션끔
        //{
        //    animator.SetBool("OnBase", false); // 달리기모션 끄고
        //    gameObject.GetComponent<Run2SecondBase>().enabled = false;
        //    gameObject.transform.localEulerAngles = new Vector3(0, 413f, 0);
        //}

        //if (gameObject.transform.position == FirstBase) // 1루에 도착하면 달리기 모션끔
        //{
        //    animator.SetBool("OnBase", false); // 달리기모션 끄고
        //    gameObject.GetComponent<Run2SecondBase>().enabled = false;
        //    gameObject.transform.localEulerAngles = new Vector3(0, 136f, 0);
        //}
    }
}
