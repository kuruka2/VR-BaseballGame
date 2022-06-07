using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_FollowCam : MonoBehaviour
{
    FollowCam FollowCam_onoff;
    // Start is called before the first frame update
    void Start()
    {
        FollowCam_onoff = GameObject.Find("Follow_Camera").GetComponent<FollowCam>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bat")
        {
          
            FollowCam_onoff.enabled = true;
        }
    }
    private void OnDestroy()
    {
        FollowCam_onoff.enabled = false;

    }

}
