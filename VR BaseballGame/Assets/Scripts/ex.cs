using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ex : MonoBehaviour
{
   

    [SerializeField] GameObject Bat_object;            //배트 오브젝트 정보를 가져온다
    [SerializeField] AudioClip Bat_hit;

    public GameObject cartridge;
    public BatCapsuleFollower aa;




    AudioSource audioSource; // 재생에 사용되는 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   // Audiosoure 컴포넌트 취득해 놓음
        aa = GetComponent<BatCapsuleFollower>();        // find 없이 함수 호출방법
    }


    public void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BaseBall")
        {

            GameObject gameObject = Instantiate(cartridge);
            gameObject.transform.position = coll.transform.position;
            audioSource.PlayOneShot(Bat_hit);   // 타격시 소리 재생


            aa.getVelocity();


            Destroy(gameObject, 3f);
            // 공 맞을때 배트의 벡터값 호출
            /*  GameObject.Find("Bat").GetComponent<BatCapsuleFollower>().FixedUpdate(); */   // 오류

            // BatCapsuleFollower 에 있는 _velocity 호출     // 오류
            //GameObject g = coll.gameObject;
            //Vector3 velocity = g.GetComponent<BatCapsuleFollower>().getVelocity();
        }

    }
  

}
