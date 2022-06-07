using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Strike : MonoBehaviour
{
    [SerializeField] GameObject Strike_text;               //STRIKE 텍스트 오브젝트
    [SerializeField] GameObject Ball_text;                 //ball 텍스트 오브젝트
    [SerializeField] GameObject Score_board;               //스코어 보드 오브젝트
    [SerializeField] GameObject Text_position;            //스코어 전광판에 뜨는 텍스트의 위치를 위한 오브젝트

    [SerializeField] Transform postionPrefab;              //strike, ball 등 3d 오브젝트 텍스트가 뜰 위치를 설정함
    [SerializeField] Transform boardposition;             //전광판에 뜰 텍스트의 위치

    [SerializeField] Transform bat;                       //배트의 움직임을 포착하기 위한 변수 (어떻게 사용할 지 모르겠음)

    [SerializeField] AudioClip Ball_Grab;                 //공잡는 소리
   
    GameObject[] array = new GameObject[10];                 //라운드별 결과를 저장할 배열
   
    AudioSource audioSource;                              //오디오를 저장할 임시 변수

    int round_count = 0;                                  //라운드 수를 재기 위한 변수 (임시로 9라운드로 설정)

    float text_position_x = 5f;                      //텍스트가 뜰 위치를 바꿀 변수



   

    public void OnCollisionEnter(Collision other)
    {
      
                                    
        if (other.collider.tag == "BaseBall")                //만약 닿은 오브젝트가 스트라이크 존이라면
        {

           
            result_strike(); 
            
            //Debug.Log("strike");
            //GameObject.Find("Bat").GetComponent<BatCapsuleFollower>().getVelocity(); // 실험


        }
        else      //만약 닿은 오브젝트가 볼 존이라면
        {
            result_ball();
           
            Debug.Log("ball");
        }


        round_count++;                         //라운드 수 변경
       


        if (round_count >= 9)                 //모든 라운드를 실행했을 경우
        {
            for (int i = 0; i < 9; i++)
            {
                Destroy(array[i]);  //저장했던 모든 텍스트 삭제

                Debug.Log("초기화");
                array[i] = null;    //초기화

                round_count = 0;   //라운드 수 초기화
                
                text_position_x = 5f;  //텍스트 위치 초기화
            }

        }


        /*Debug.Log("라운드 카운트 : " + round_count);*/   //설명
       
    }

    public void result_ball()
    {
        audioSource = GetComponent<AudioSource>(); // 컴포넌트 취득해놈
       
        var text = Instantiate(Ball_text, transform.position, postionPrefab.rotation);          //Zone에 뜨는 ball 텍스트

        audioSource.PlayOneShot(Ball_Grab);   //오디오 실행

        Destroy(text, 1.0f);    //볼 텍스트가 뜨고 1초 뒤에 삭제

        Text_position.transform.position = new Vector3(36 - text_position_x, 36.9f, -87.22f);          //전광판에 뜰 텍스트의 위치 선정 ->텍스트 포지션 x 변수에 따라 위치가 달라진다

        var result = Instantiate(Ball_text, Text_position.transform.position, boardposition.rotation);   //위치에 따라 전광판에 텍스트 생성


        array[round_count] = result;                                                                      //배열에 텍스트 오브젝트 저장


        text_position_x += 5;                  //텍스트 등장위치 변경을 위해 x축 값을 더함

       
    }

    public void result_strike()
    {
        audioSource = GetComponent<AudioSource>();                                          // 컴포넌트 취득해놈
        var text = Instantiate(Strike_text, transform.position, postionPrefab.rotation);          //Zone에 뜨는 strike 텍스트

        audioSource.PlayOneShot(Ball_Grab);                                                          //오디오 실행

        Destroy(text, 1.0f);                                                                            //스트라이크 텍스트가 뜨고 1초 뒤에 삭제

        Text_position.transform.position = new Vector3(36 - text_position_x, 36.9f, -87.22f);          //전광판에 뜰 텍스트의 위치 선정

        var result = Instantiate(Strike_text, Text_position.transform.position, boardposition.rotation);   //전광판에 텍스트 생성


        array[round_count] = result;                                                                      //배열에 텍스트 오브젝트 저장


        text_position_x += 5;                                                                    //텍스트 등장위치 변경을 위해 x축 값을 더함

     
    }

}
