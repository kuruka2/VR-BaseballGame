using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run2FirstBase : MonoBehaviour
{
    Vector3 FirstBase = new Vector3(-38.36f,0,-38.44f); // 1��

    private Animator animator; // �ִϸ�����
    public GameObject OnBaseHitter; // ���Ÿ��

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, FirstBase, 0.025f); // 1��� �޸�
        animator.SetBool("OnBase", true); // �޸��� ��� Ű�� 

        if (gameObject.transform.position == FirstBase) // 1�翡 �����ϸ� �޸��� ��ǲ�
        {
            animator.SetBool("OnBase", false); // �޸����� ����
            gameObject.GetComponent<Run2FirstBase>().enabled = false; // �޸��� ��ũ��Ʈ ����
            gameObject.transform.localEulerAngles = new Vector3(0, 136f, 0); //���� 2���
        }
    }
}
