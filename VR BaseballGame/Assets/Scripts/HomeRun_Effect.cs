using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeRun_Effect : MonoBehaviour
{

    [SerializeField] GameObject Homerun_Effect;
    [SerializeField] AudioClip Crowd_clip;

    AudioSource audioSource; // 관중 소리 변수

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("BaseBall"))
        {
            GameObject gameObject = Instantiate(Homerun_Effect);
            gameObject.transform.position = coll.transform.position;
            audioSource.PlayOneShot(Crowd_clip);   // 타격시 소리 재생

            
        }
    }


}
