using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeRun_Effect : MonoBehaviour
{

    [SerializeField] GameObject Homerun_Effect;
    [SerializeField] AudioClip Crowd_clip;

    AudioSource audioSource; // ���� �Ҹ� ����

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
            audioSource.PlayOneShot(Crowd_clip);   // Ÿ�ݽ� �Ҹ� ���

            
        }
    }


}
