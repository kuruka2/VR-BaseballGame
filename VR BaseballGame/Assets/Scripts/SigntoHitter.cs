using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigntoHitter : MonoBehaviour
{
    public GameObject OnBaseHiiter1; // 출루타자
    public GameObject OnBaseHiiter2; // 출루타자
    public GameObject OnBaseHiiter3; // 출루타자
    public GameObject OnBaseHiiter4; // 출루타자

    public GameObject Strike1;
    public GameObject Strike2;
    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject Ball3;

    [SerializeField] public static int WhoRun = 0;

    [SerializeField] public static int Run1 = 0; // 첫번째 출루타자
    [SerializeField] public static int Run2 = 0; // 두번째 출루타자
    [SerializeField] public static int Run3 = 0; // 세번째 출루타자
    [SerializeField] public static int Run4 = 0; // 세번째 출루타자

    IEnumerator RunDelay1()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Run1 = 0;
    }
    IEnumerator RunDelay2()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Run2 = 0;
    }
    IEnumerator RunDelay3()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Run3 = 0;
    }
    IEnumerator RunDelay4()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Run4 = 0;
    }
    IEnumerator ResetWhorun()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        WhoRun = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
 
    public void OnCollisionEnter(Collision other) // RunController로 신호줌 (출루타자), 각베이스로 신호줌
    {
        if (other.gameObject.name == "BaseBall(Clone)")
        {
            Zone.Strike_counts = 0;
            Zone.Ball_counts = 0;

            Strike1.SetActive(false);
            Strike2.SetActive(false);

            Ball1.SetActive(false);
            Ball2.SetActive(false);
            Ball3.SetActive(false);

            if (WhoRun==3) // 3이면 네번째 애가 달림
            {
                OnBaseHiiter4.SetActive(true); //타자 오브젝트 활성화
            }
            if (WhoRun==2) // 2이면 세번째 애가 달림
            {
                OnBaseHiiter3.SetActive(true); //타자 오브젝트 활성화
            }
            if (WhoRun==1) // 1이면 두번째애가 달리고
            {
                OnBaseHiiter2.SetActive(true); //타자 오브젝트 활성화
            }

            OnBaseHiiter1.SetActive(true); //타자 오브젝트 활성화
            OnBaseHiiter1.SendMessage("RuntoBase", Run1); // RunController 로 신호보냄
            Run1++;
            WhoRun++; // 0이면 젤처음 애가 달리고

            if(Run1>=4)
            {
                StartCoroutine(RunDelay1());
            }

            if(WhoRun==4)
            {
                StartCoroutine(ResetWhorun());
            }

            if (OnBaseHiiter2.activeSelf == true)
            {
                OnBaseHiiter2.SendMessage("RuntoBase", Run2); // RunController 로 신호보냄
                Run2++;
                if (Run2 >= 4)
                {
                    StartCoroutine(RunDelay2());
                }
            }

            if (OnBaseHiiter3.activeSelf == true)
            {
                OnBaseHiiter3.SendMessage("RuntoBase", Run3); // RunController 로 신호보냄
                Run3++;
                if (Run3 >= 4)
                {
                    StartCoroutine(RunDelay3());
                }
            }

            if(OnBaseHiiter4.activeSelf == true)
            {
                OnBaseHiiter4.SendMessage("RuntoBase", Run4); // RunController 로 신호보냄
                Run4++;
                if (Run4 >= 4)
                {
                    StartCoroutine(RunDelay4());
                }
            }
            //Debug.Log("WhoRun: "+WhoRun);
        }
    }
}
