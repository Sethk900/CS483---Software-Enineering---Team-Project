using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //Enemy Parameters
	public float health = 10f;
	public float bulletSpeed = 10f;
	public float bulletFrequency = 300;

	//Used to track update cycles since last bullet
	public float bulletTimer;

	//the rigid body and the player and the bullet prefab
	public Rigidbody2D rb;	
	public playerControl thePlayer;
	public GameObject bulletPrefab;

    //Vector of the player's position and an instance of the bullet control script
	Vector2 playerDirection;
	bulletControl bcInst;

	// Start is called before the first frame update
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<playerControl>();
		bcInst = GetComponent<bulletControl>();
    }
	
	// Called once every frame
	void Update() 
	{
		playerDirection = thePlayer.rb.position - rb.position;
		playerDirection.Normalize();
	}

	/* 
	* Called 50 times a second rather than every frame.
	* This makes physics placed here more reliable as
	* it isn't locked to the frame rate.
	*/
	void FixedUpdate () 
	{
		AttackBehavior();
    }
	
	//Handle collisions
	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.gameObject.tag.Equals("PlayerBullet")) 
		{
			DamageEnemy(2.5f);
		}
	}

	// Enemy attack behavior
	void AttackBehavior () {
		if (bulletTimer >= bulletFrequency) 
		{
			bcInst.Shoot(rb.position, playerDirection, bulletSpeed, bulletPrefab);
			bulletTimer = 0;
		} 
		else 
		{
			bulletTimer++;
		}
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
