using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testex : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ex1 = false;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BaseBall(Clone)")
        {
            ex1 = true;
        }

    }
}
