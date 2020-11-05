using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRightFistBehavior : MonoBehaviour
{
    //Rigid body
	public Rigidbody2D rb;	


	// Start is called before the first frame update
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Called once every frame
	void Update() 
	{
		
	}

	/* 
	* Called 50 times a second rather than every frame.
	* This makes physics placed here more reliable as
	* it isn't locked to the frame rate.
	*/
	void FixedUpdate () 
	{
	
    }
	
	//Handle collisions
	void OnCollisionEnter2D(Collision2D col) 
	{
		
	}

	// Enemy attack behavior
	void AttackBehavior () 
	{
		
	}
}
