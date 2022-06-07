using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsule : MonoBehaviour
{
    [SerializeField] private BatCapsuleFollower _batCapsuleFollowerPrefab;
    BatCapsuleFollower batfollwer;

    private void SpawnBatCapsuleFollower()  // 자기 자신 복제해 배트에 붙음
    {
        var follower = Instantiate(_batCapsuleFollowerPrefab);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);

    }


    void Start()
    {
        SpawnBatCapsuleFollower();

    }

  
}
