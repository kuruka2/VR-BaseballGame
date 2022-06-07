using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class trail_randerer : MonoBehaviour
{
    // Start is called before the first frame update

    TrailRenderer on_off;

   public void Start()
    {
        on_off = GetComponent<TrailRenderer>();
        on_off.enabled = false;
    }

    public void OnCollisionEnter(Collision other)
    {
        on_off.enabled=true;
         
    }
}