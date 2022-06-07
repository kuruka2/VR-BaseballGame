using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private Animator animator;

    Vector3 points;
    public void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Throwing", true);
        //animator.SetBool("Throwing", false);
    }
    public void OnDisable()
    {
        animator.SetBool("Throwing", false);
        gameObject.GetComponent<Throw>().enabled = false;
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        Vector3 vector3 = new Vector3(-1, 1, -37);
        gameObject.transform.position = vector3;
    }
}
