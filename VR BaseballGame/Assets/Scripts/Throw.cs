using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private Animator animator;

    Vector3 points;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void Update()
    {
        if(Input.GetButtonUp("Fire1")) // ±×³É º¼
        {
            animator.SetBool("Throwing", true);
        }
      
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Pitcher_pitch") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
          
            animator.SetBool("Throwing", false);
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            Vector3 vector3 = new Vector3(-1, 0.44f, -37);
            gameObject.transform.position = vector3;
        }
    }
}
