using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController: MonoBehaviour
{
    void RuntoBase(int Run)
    {
        if (Run%4 == 0) // ��Ʈ�� ������ ���
        {
            gameObject.GetComponent<Run2FirstBase>().enabled = true;
        }

        if (Run%4 == 1) // ��Ʈ�� ������ ���
        {
            gameObject.GetComponent<Run2SecondBase>().enabled = true;
        }

        if (Run%4 == 2) // ��Ʈ�� ������ ���
        {
            gameObject.GetComponent<Run2ThirdBase>().enabled = true;
        }

        if (Run%4 == 3) // ��Ʈ�� ������ ���
        {
            gameObject.GetComponent<Run2HomeBase>().enabled = true;
        }
    }
}