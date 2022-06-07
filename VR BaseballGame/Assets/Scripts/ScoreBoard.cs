using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] public Zone zone;

    public GameObject Strike1;

    public GameObject Strike2;

    public GameObject Ball1;

    public GameObject Ball2;

    public GameObject Ball3;

    public GameObject Out1;

    public GameObject Out2;

    IEnumerator StrikeOffDelay1() // 스트라이크 꺼지고 아웃 들어오기전 딜레이
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Strike1.SetActive(false);
        Strike2.SetActive(false);
    }

    IEnumerator OutOnDelay1() // 아웃 켜지는 딜레이
    {
        yield return new WaitForSecondsRealtime(0.6f);
        Out1.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Zone.Out_counts == 1)
        {
            Out1.SetActive(true);
        }

        if (Zone.Out_counts == 2)
        {
            Out2.SetActive(true);
        }

        if (Zone.Out_counts == 3)
        {
            Out1.SetActive(false);
            Out2.SetActive(false);
        }

        if (Zone.Strike_counts == 1)
        {
            Strike1.SetActive(true);
        }

        if (Zone.Strike_counts == 2)
        {
            Strike2.SetActive(true);
        }

        if (Zone.Strike_counts == 3) //3 스트라이크하면 
        {
            StartCoroutine(StrikeOffDelay1()); // 딜레이주고 스트라이크 전부꺼짐
        }

        if (Zone.Ball_counts == 1)
        {
            Ball1.SetActive(true);
        }

        if (Zone.Ball_counts == 2)
        {
            Ball2.SetActive(true);
        }

        if (Zone.Ball_counts == 3)
        {
            Ball3.SetActive(true);
        }

        if (Zone.Ball_counts == 4)
        {
            Debug.Log("볼넷");
        }

    }
}
