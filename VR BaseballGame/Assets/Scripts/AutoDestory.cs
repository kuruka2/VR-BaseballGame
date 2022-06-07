using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour
{
    [SerializeField] float lifetime = 5f; // 게임 오브젝트 수명

    // Start is called before the first frame update
    void Start()
    {
        // 일정 시간 경과후 공을 없앰
        Destroy(gameObject, lifetime);
    }

    
}
