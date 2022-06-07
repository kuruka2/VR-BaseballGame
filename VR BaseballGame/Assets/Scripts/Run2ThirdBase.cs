using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run2ThirdBase : MonoBehaviour
{
    Vector3 ThirdBase = new Vector3(38.57f, 0, -38.24f); // 3��

    private Animator animator; // �ִϸ�����
    public GameObject OnBaseHitter; // ���Ÿ��

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ThirdBase, 0.025f); // 1��� �޸�
        animator.SetBool("OnBase", true); // �޸��� ��� Ű�� 

        if (gameObject.transform.position == ThirdBase) // 1�翡 �����ϸ� �޸��� ��ǲ�
        {
            animator.SetBool("OnBase", false); // �޸����� ����
            gameObject.GetComponent<Run2ThirdBase>().enabled = false; // �޸��� ��ũ��Ʈ ����
            gameObject.transform.localEulerAngles = new Vector3(0, 311f, 0); //Ȩ��ٶ�
        }
    }
}
