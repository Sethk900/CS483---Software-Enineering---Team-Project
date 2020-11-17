using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleControl : MonoBehaviour
{
	public Animator animator;
	//Enemy Parameters
	public float health = 10f;

    //Rigid body, player search, bullet prefab
	public Rigidbody2D rb;	
	public playerControl thePlayer;
	public GameObject bulletPrefab;
	public float timer;
	
	

	// Start is called before the first frame update
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<playerControl>();
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
			timer = 0.25f;
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
	}
}
