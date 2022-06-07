using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruJudge : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.H))
        {
            if (gameObject.name == "1루수심판")
            {
               
                animator.SetBool("Safe", true);
            }
        }

        if(Input.GetKey(KeyCode.J))
        {
            if (gameObject.name == "3루수심판")
            {
                animator.SetBool("Safe", true);
            }
        }

        if(Input.GetKey(KeyCode.K))
        {
            if (gameObject.name == "1루수심판")
            {
                animator.SetBool("Out", true);
            }
        }

        if (Input.GetKey(KeyCode.L))
        {
            if (gameObject.name == "3루수심판")
            {
                animator.SetBool("Out", true);
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Judge_Safe") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            animator.SetBool("Safe", false);
            if(gameObject.name=="1ru_Judge")
            {
                gameObject.transform.rotation = new Quaternion(0, 140, 0, 0);
                gameObject.transform.position = new Vector3(-46, 1, -29);
            }
            if (gameObject.name == "3ru_Judge")
            {
                gameObject.transform.rotation = new Quaternion(0, 220, 0, 0);
                gameObject.transform.position = new Vector3(46, 1, -30);
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Judge_Out") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            animator.SetBool("Out", false);
            if (gameObject.name == "1ru_Judge")
            {
                gameObject.transform.rotation = new Quaternion(0, 140, 0, 0);
                gameObject.transform.position = new Vector3(-46, 1, -29);
            }
            if (gameObject.name == "3ru_Judge")
            {
                gameObject.transform.rotation = new Quaternion(0, 220, 0, 0);
                gameObject.transform.position = new Vector3(46, 1, -30);
            }
        }
    }
}
