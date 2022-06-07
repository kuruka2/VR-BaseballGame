using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Follow_Ball : MonoBehaviour
{
    private Animator animator;
    public Baseball_height height_on;
    GameObject baseball1;

    NomalShoot NomalShoot;

    Follow_Ball follow_Ball;
    NavMeshAgent nav;
    Transform target;
    Quaternion thistr;
    Transform Target;
    Vector3 rotation;
    Vector3 point;


    // Start is called before the first frame update

    public void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);

        nav = GetComponent<NavMeshAgent>();

        target = GameObject.Find("target").GetComponent<Transform>();

        //height_on.enabled = true; // 공 높이랑 위치 가져오기.

        baseball1 = GameObject.Find("BaseBall(Clone)");

        thistr = gameObject.transform.rotation;

        point = gameObject.transform.position;
       
        
    }

    public void OnDisable()
    {
        this.nav.isStopped = true;  // 오브젝트 미끄러짐 멈춤 
        this.nav.velocity = Vector3.zero;   // velocity가 zero로 될때까지 미끄러지기 때문에 바로 zero로 바꿔줌.
        nav.ResetPath();
        //animator.SetBool("flyball", false);
        animator.SetBool("stay", false);
        animator.SetBool("Run", false);
        //animator.SetBool("groundball", false);

        //height_on.enabled = false;

        gameObject.transform.position = point;
        gameObject.transform.rotation = thistr;
    }
    private void Move()
    {

    }
    // -0.214 -90.093 -0.024
    // Update is called once per frame
    void FixedUpdate()
    {
    
        if (target == true)
        {
            nav.SetDestination(target.position);
            animator.SetFloat("Baseball_height", baseball1.transform.position.y);
            animator.SetFloat("Baseball_position", Vector3.Distance(gameObject.transform.position, baseball1.transform.position));

            if(NomalShoot.baseball_Ground == true)
            {
                nav.SetDestination(baseball1.transform.position);
            }

            if (gameObject.transform.position.z <= target.position.z + 5 || gameObject.transform.position.z >= target.position.z + 5)
            {
                animator.SetBool("stay", true);
                // 공 잡는 모션
            
            }
        }
    }
}