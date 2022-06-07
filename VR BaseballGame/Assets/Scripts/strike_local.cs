using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strike_local : MonoBehaviour
{

    Vector3 LocalPosition(Vector3 local)
    {
        Vector3 a;
        a.x = -local.x * 10;
        a.y = local.z * 10;
        a.z = 0;
 
        return gameObject.transform.localPosition=a;
    }

    void Start()
    {
        
    }

  
    void Update()
    {
        //Debug.Log(gameObject.transform.localPosition);
    }
}
