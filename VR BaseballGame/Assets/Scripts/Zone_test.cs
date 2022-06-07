using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_test : MonoBehaviour
{


    public GameObject strike_position; 

    void OnCollisionEnter(Collision other)    // 스트라이크존 UI
    {

        if (other.gameObject.tag == "BaseBall")
        {
            Vector3 a = other.transform.localPosition;
      
            strike_position.SendMessage("LocalPosition",a);

        }

    }

}
