using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public Run2HomeBase Run2HomeBase;
    [SerializeField] public SigntoHitter SigntoHitter;
    [SerializeField] public static int Strike_counts = 0;
    [SerializeField] public static int Out_counts = 0;
    [SerializeField] public static int Ball_counts = 0;
    [SerializeField] public static int AttackChange = 0;

    [SerializeField] public static int Inning = 1; // �̴�
    [SerializeField] public static int ChangeTeam = 0;// ¦���� Ȩ Ȧ���� �����

    public GameObject Scene;

    public bool Faul = false;
    public bool Ball = false;
    public bool FourBall = false;
    public bool Strike = false;
    public bool StrikeOut = false;

    public GameObject target; // ���� 
    public GameObject target2; // ����
    public GameObject Bat; // ��Ʈ

    public GameObject ScoreBoard; // ���ھ��
    public GameObject JudgeStrike; // �ؿ��ߴ°�
    public GameObject JudgeBall; // �ؿ��ߴ°�
    public GameObject JudgeOut; // �ؿ��ߴ°�

    public GameObject OnBaseHiiter1; // ���Ÿ��
    public GameObject OnBaseHiiter2; // ���Ÿ��
    public GameObject OnBaseHiiter3; // ���Ÿ��
    public GameObject OnBaseHiiter4; // ���Ÿ��

    IEnumerator StrikeDelay()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        JudgeStrike.SetActive(false);
    }

    IEnumerator Strike3()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Strike_counts = 0;
    }

    IEnumerator Out3()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Out_counts = 0;
    }

    IEnumerator BallDelay()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        JudgeBall.SetActive(false);
    }

    IEnumerator Strikeoff()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        offStrike();
    }
    IEnumerator Balloff()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        offBall();
    }

    IEnumerator OutSet()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        JudgeOut.SetActive(true);
        JudgeOut.SetActive(false);
        StrikeOut = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Debug.Log("Inning:" + Inning + "ChangeTeam: "+ ChangeTeam);
        }
        if (Input.GetKey(KeyCode.N))
        {
            Debug.Log("Run1: " + SigntoHitter.Run1 + " Run2: " + SigntoHitter.Run2 + " Run3: " + SigntoHitter.Run3 + " Run4: " + SigntoHitter.Run4 + " WhoRun: " + SigntoHitter.WhoRun);
        }

    }

    void SetScore()
    {
        if (Strike == true)
        {
            Debug.Log("Strike..!");
            Strike_counts++;
            StartCoroutine(Strikeoff());

            if (Strike_counts == 3)
            {
                StrikeOut = true;
                Out_counts++;
                StartCoroutine(Strike3());
                OutSet();
            }
            if (Out_counts == 3)
            {
                Scene.SetActive(true);
                StartCoroutine(Out3());
                Debug.Log("Change");
                ChangeTeam++; // ��������
         
                OnBaseHiiter1.transform.localEulerAngles = new Vector3(0, 226f, 0); // �����ʱ�ȭ
                OnBaseHiiter1.transform.position=new Vector3(0,0,0);

                OnBaseHiiter2.transform.localEulerAngles = new Vector3(0, 226f, 0); // �����ʱ�ȭ
                OnBaseHiiter2.transform.position = new Vector3(0, 0, 0);

                OnBaseHiiter3.transform.localEulerAngles = new Vector3(0, 226f, 0); // �����ʱ�ȭ
                OnBaseHiiter3.transform.position = new Vector3(0, 0, 0);

                OnBaseHiiter4.transform.localEulerAngles = new Vector3(0, 226f, 0); // �����ʱ�ȭ
                OnBaseHiiter4.transform.position = new Vector3(0, 0, 0);

                OnBaseHiiter1.SetActive(false);
                OnBaseHiiter2.SetActive(false);
                OnBaseHiiter3.SetActive(false);
                OnBaseHiiter4.SetActive(false);
                SigntoHitter.Run1 = 0;
                SigntoHitter.Run2 = 0;
                SigntoHitter.Run3 = 0;
                SigntoHitter.Run4 = 0;
                SigntoHitter.WhoRun = 0;
            }

            target.SendMessage("SetStrike", true);
            JudgeStrike.SetActive(true); // �ؿ� ��Ʈ����ũ��
            StartCoroutine(StrikeDelay());
            if (StrikeOut == true)
            {
                Strike = false;
                target.SendMessage("SetStrikeOut", true);
            }
        }
        if (Strike == false)
        {
            if (Ball_counts == 4)
            {
                Debug.Log("FourBall!");
                Ball_counts = 0;
                FourBall = true;
                Strike_counts = 0;
            }
        }
        if (Ball == true)
        {
            Debug.Log("Ball..!");
            Ball_counts++;
            if (Ball_counts == 4)
            {
                Debug.Log("FourBall!");
                Ball_counts = 0;
                FourBall = true;
            }
            StartCoroutine(Balloff());

            target.SendMessage("SetBall", true);
            JudgeBall.SetActive(true); // �ؿ� ����
            StartCoroutine(BallDelay());
        }
        if (Faul == true)
        {
            Debug.Log("Faul.!");
            Strike_counts++;
            SetScore();
            if (Strike_counts == 3)
            {
                Out_counts++;
                Strike_counts = 0;
            }
            if (Out_counts == 3)
            {
                Out_counts = 0;
                Debug.Log("Change");
            }
        }
        Debug.Log("Strike:" + Strike_counts);
        Debug.Log("Ball:" + Ball_counts);
        Debug.Log("Out:" + Out_counts);
    }

    void offStrike()
    {
        Strike = false;
    }
    void offBall()
    {
        Ball = false;
    }
    void offOut()
    {
        StrikeOut = false;
    }

    void OutOff()
    {
        JudgeOut.SetActive(false);
    }

    void OutOn()
    {
        JudgeOut.SetActive(true);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "BaseBall(Clone)")
        {
            if (gameObject.tag == "Faul")
            {
                Faul = true;
                SetScore();
                Destroy(other.gameObject);
            }
            if (gameObject.name == "Strike_Zone") // ��Ʈ����ũ�� 
            {
                target2.SendMessage("SetCatch", true); // ĳġ����
                Strike = true;
                SetScore();
            }
            if (gameObject.name == "Ball_Zone") // ��Ʈ����ũ�� 
            {
                Ball = true;
                Destroy(other.gameObject);
                SetScore();
            }
        }
    }
}
