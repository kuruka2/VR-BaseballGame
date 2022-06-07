using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class bat : MonoBehaviour
{
    [SerializeField] float angularVelocity = 30f;

    [SerializeField] GameObject Bat_object;            //배트 오브젝트 정보를 가져온다
    [SerializeField] AudioClip Bat_hit;

    Rigidbody rigi_velo;

    public GameObject cartridge;
    float horizontalAngle = 0f; // 수평 방향의 회전량을 저장
    float verticalAngle = 0f; // 수직 방향의 회전량을 저장

    AudioSource audioSource; // 재생에 사용되는 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   // Audiosoure 컴포넌트 취득해 놓음
        rigi_velo = gameObject.GetComponent<Rigidbody>();
       

    }

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BaseBall")
        {

            GameObject gameObject = Instantiate(cartridge);
            gameObject.transform.position = coll.transform.position;
            audioSource.PlayOneShot(Bat_hit);   // 타격시 소리 재생

            // 공 맞을때 배트의 벡터값 호출
            Debug.Log("배트에 맞는경우");

        }

    }
    void Update()
    {

        //Debug.Log();
        //입력에 따라 회전량을 취득

        var horizontalRotation = Input.GetAxis("Horizontal") * angularVelocity * Time.deltaTime * 15;
        var verticalRotation = -Input.GetAxis("Vertical") * angularVelocity * Time.deltaTime * 15;

        // 회전량을 갱신
        horizontalAngle += horizontalRotation;
        verticalAngle += verticalRotation;

        // 수직 방향은 너무 회전하지 않게 제한

        verticalAngle = Mathf.Clamp(verticalAngle, -80f, 80f);

        //Transform 컴포넌트에 회전량을 적용
        transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);

    }



}
