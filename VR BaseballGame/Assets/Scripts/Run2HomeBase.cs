using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run2HomeBase : MonoBehaviour
{
    [SerializeField] public Zone zone;
    [SerializeField] static public int HomeScore = 0; // Ȩ ���ھ�
    [SerializeField] static public int AwayScore = 0; // ����� ���ھ� 
    [SerializeField] static public int testscore = 0; // ����� ���ھ�
                                                      // 
    [SerializeField] static public bool Home = false;
    [SerializeField] static public bool Away = false;
    int totalHome = 0;
    int totalAway = 0;
    Vector3 HomeBase = new Vector3(0, 0, 0); // Home

    private Animator animator; // �ִϸ�����
    public GameObject OnBaseHitter; // ���Ÿ��

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
            transform.position = Vector3.MoveTowards(transform.position, HomeBase, 0.025f); // Ȩ���
            animator.SetBool("OnBase", true); // �޸��� ��� Ű�� 

            if (gameObject.transform.position == HomeBase) // �翡 �����ϸ� �޸��� ��ǲ�
            {
                animator.SetBool("OnBase", false); // �޸����� ����
                gameObject.GetComponent<Run2HomeBase>().enabled = false; // �޸��� ��ũ��Ʈ ����
                this.gameObject.SetActive(false);
                if (Zone.ChangeTeam % 2 == 0)// Ȩ���� �������� -> ������ ����
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
