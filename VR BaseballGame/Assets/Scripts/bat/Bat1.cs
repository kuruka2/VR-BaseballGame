using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "BaseBall(Clone)")
        {
            //target.SendMessage("BatCollision","1");
        }
    }
}
