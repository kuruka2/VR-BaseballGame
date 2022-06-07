using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run2HomeBase : MonoBehaviour
{
    [SerializeField] public Zone zone;
    [SerializeField] static public int HomeScore = 0; // 홈 스코어
    [SerializeField] static public int AwayScore = 0; // 어웨이 스코어 
    [SerializeField] static public int testscore = 0; // 어웨이 스코어
                                                      // 
    [SerializeField] static public bool Home = false;
    [SerializeField] static public bool Away = false;
    int totalHome = 0;
    int totalAway = 0;
    Vector3 HomeBase = new Vector3(0, 0, 0); // Home

    private Animator animator; // 애니메이터
    public GameObject OnBaseHitter; // 출루타자

    void Start()
    {
        if(gameObject==OnBaseHitter)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject==OnBaseHitter)
        {
            transform.position = Vector3.MoveTowards(transform.position, HomeBase, 0.025f); // 홈루로
            animator.SetBool("OnBase", true); // 달리기 모션 키고 

            if (gameObject.transform.position == HomeBase) // 루에 도착하면 달리기 모션끔
            {
                animator.SetBool("OnBase", false); // 달리기모션 끄고
                gameObject.GetComponent<Run2HomeBase>().enabled = false; // 달리기 스크립트 끄고
                this.gameObject.SetActive(false);
                if (Zone.ChangeTeam % 2 == 0)// 홈팀이 먼저시작 -> 그이후 점수
                {
                    Home = true;
                    Away = false;
                    HomeScore++;
                    Debug.Log("Home: " + HomeScore);
                    Debug.Log("Away: " + AwayScore);
                }
                if (Zone.ChangeTeam % 2 == 1)
                {
                    Home = false;
                    Away = true;
                    AwayScore++;
                    Debug.Log("Home: " + HomeScore);
                    Debug.Log("Away: " + AwayScore);
                }
                gameObject.transform.localEulerAngles = new Vector3(0, 226f, 0);
            }
        }
    }

    void totalScore()
    {
        totalAway += AwayScore;
        totalHome += HomeScore;
    }
}
