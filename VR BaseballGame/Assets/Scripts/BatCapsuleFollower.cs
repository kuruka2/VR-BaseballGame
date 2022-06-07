using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsuleFollower : MonoBehaviour
{
	 BatCapsule _batFollower;
	 Rigidbody _rigidbody;
	 Vector3 _velocity;
	 Vector3 vel;		// 배트

	[SerializeField]	private float _sensitivity = 100f;
	bool isStarted = false;
	private void Awake()
	{
	
		_rigidbody = GetComponent<Rigidbody>();
       
    }

	private void FixedUpdate()
	{
        if (isStarted) {			// 캡슐이 공을 따라가게 만듬
			Vector3 destination = _batFollower.transform.position;
			_rigidbody.transform.rotation = transform.rotation;

			_velocity = (destination - _rigidbody.transform.position) * _sensitivity;

			_rigidbody.velocity = _velocity;
			transform.rotation = _batFollower.transform.rotation;
			
		}
		
		
	}
  
    public float getVelocity()
    {
		float a,b,c,d;
		a = _velocity.x;
		b = _velocity.y;
		c = _velocity.z;
		d = Mathf.Sqrt(a * a + b * b + c * c);
	
        return d;
    }

	//public void setVelocity(Vector3 v)
	//{
 //       _velocity = v;

 //   }

	public void SetFollowTarget(BatCapsule batFollower)
	{
		_batFollower = batFollower;
		isStarted = true;
	}
}
