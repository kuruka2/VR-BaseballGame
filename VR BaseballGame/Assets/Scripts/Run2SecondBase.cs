using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run2SecondBase : MonoBehaviour
{
    Vector3 FirstBase = new Vector3(-38.36f, 0, -38.44f); // 1��
    Vector3 SecondBase = new Vector3(-0.06f,0,-77.3f); // 2��

    private Animator animator; // �ִϸ����� 
    public GameObject OnBaseHitter; // ���Ÿ��

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.B))
        {
            gameObject.transform.localEulerAngles = new Vector3(0,-34f, 0); //���� 2���
            transform.position = Vector3.MoveTowards(transform.position, FirstBase, 0.066f);
            animator.SetBool("OnBase", true);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, SecondBase, 0.025f); // 1��� �޸�
            animator.SetBool("OnBase", true); // �޸��� ��� Ű�� 

            if (gameObject.transform.position == SecondBase) // 1�翡 �����ϸ� �޸��� ��ǲ�
            {
                animator.SetBool("OnBase", false); // �޸����� ����
                gameObject.GetComponent<Run2SecondBase>().enabled = false;
                gameObject.transform.localEulerAngles = new Vector3(0, 413f, 0);
            }

            if (gameObject.transform.position == FirstBase) // 1�翡 �����ϸ� �޸��� ��ǲ�
            {
                animator.SetBool("OnBase", false); // �޸����� ����
                gameObject.GetComponent<Run2SecondBase>().enabled = false;
                gameObject.transform.localEulerAngles = new Vector3(0, 136f, 0);
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position, SecondBase, 0.066f); // 1��� �޸�
        //animator.SetBool("OnBase", true); // �޸��� ��� Ű�� 

        //if (gameObject.transform.position == SecondBase) // 1�翡 �����ϸ� �޸��� ��ǲ�
        //{
        //    animator.SetBool("OnBase", false); // �޸����� ����
        //    gameObject.GetComponent<Run2SecondBase>().enabled = false;
        //    gameObject.transform.localEulerAngles = new Vector3(0, 413f, 0);
        //}

        //if (gameObject.transform.position == FirstBase) // 1�翡 �����ϸ� �޸��� ��ǲ�
        //{
        //    animator.SetBool("OnBase", false); // �޸����� ����
        //    gameObject.GetComponent<Run2SecondBase>().enabled = false;
        //    gameObject.transform.localEulerAngles = new Vector3(0, 136f, 0);
        //}
    }
}
