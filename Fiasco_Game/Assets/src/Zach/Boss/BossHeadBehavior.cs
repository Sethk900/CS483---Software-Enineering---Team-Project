using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    public Animator animator;
	//Enemy Parameters
	public float health = 50f;
    public float bossDamageableTimer;
    //Rigid body, player search, bullet prefab
	public Rigidbody2D rb;	
	public float timer;
	public GameObject leftFist;
    public GameObject rightFist;

	// Start is called before the first frame update
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
        leftFist = GameObject.FindWithTag("LeftFist");
        rightFist = GameObject.FindWithTag("RightFist");	
    }
	
	// Called once every frame
	void Update() 
	{
		if(timer >= 0)
		{
		timer -= Time.deltaTime;
		}
	}
	/* 
	* Called 50 times a second rather than every frame.
	* This makes physics placed here more reliable as
	* it isn't locked to the frame rate.
	*/
	void FixedUpdate () 
	{
		AttackBehavior();
		if(timer <= 0)
		{
		animator.SetBool("damaged", false);
		}
    }
	
	//Handle collisions
	void OnCollisionEnter2D(Collision2D col) 
	{
        
		if (col.gameObject.tag.Equals("PlayerBullet")) 
		{
			DamageEnemy(2.5f);
			timer = 0.30f;
			animator.SetBool("damaged", true);
		}
	}

	// Enemy attack behavior
	void AttackBehavior () 
	{

	}

	// Handle Enemy taking damage
	void DamageEnemy(float damage) 
	{
		health -= damage;
		if (health <= 0) 
		{
			EnemyDeath();
			UIScript.score+=1; //Increment the score
		}
	}
	
	// Handle Enemy Death
	void EnemyDeath() 
	{
		Destroy(gameObject);
        Destroy(rightFist);
        Destroy(leftFist);
    }
}
