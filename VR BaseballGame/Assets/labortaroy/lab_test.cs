using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class lab_test : MonoBehaviour
{

    public Transform dest;
    Vector3 endpos = new Vector3(20, 0, 0);
    void Start()
    {
        StartCoroutine(Test());

    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1f);
        //transform.DOMoveX(dest.position.x, 3).SetEase(Ease.OutQuad);
        //transform.DOMoveY(dest.position.y, 3).SetEase(Ease.OutQuad);
        //transform.DOMoveZ(dest.position.z, 3).SetEase(Ease.OutQuad);
        transform.DOJump(dest.transform.position, 30, 1, 3f, false); // 포물선 운동.
    }

}
