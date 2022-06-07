using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jubge : MonoBehaviour
{
    private Animator animator;

    bool Fauls = false;
    bool Balls = false;
    bool Strikes = false;
    bool StrikeOuts = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void SetStrike(bool receiveStrike) // Zone 스크립트에서 받아옴
    {
        if (receiveStrike == true)
        {
            animator.SetBool("Strike", true);
        }
    }

    void SetBall(bool receiveBall) // Zone 스크립트에서 받아옴
    {
        if (receiveBall == true)
        {
            animator.SetBool("Ball", true);
        }
    }
    void SetStrikeOut(bool receiveStrikeOut) // Zone 스크립트에서 받아옴
    {
        if (receiveStrikeOut == true)
        {
            animator.SetBool("StrikeOut", true);
        }
    }
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Judge_strike") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            animator.SetBool("Strike", false);
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);           
            gameObject.transform.position = new Vector3(-0.1f, 0, 9.0f);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Judge_ball") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            animator.SetBool("Ball", false);
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            gameObject.transform.position = new Vector3(-0.1f, 0, 9.0f);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Judge_StrikeOut") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        {
            animator.SetBool("StrikeOut", false);
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            gameObject.transform.position = new Vector3(-0.1f, 0, 9.0f);
        }
    }
}
