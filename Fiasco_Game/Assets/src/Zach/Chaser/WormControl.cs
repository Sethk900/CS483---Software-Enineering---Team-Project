using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WormControl : MonoBehaviour
{
	public Animator animator;
	//Enemy Parameters
	public float health = 10f;

	public Rigidbody2D rb;	
	public playerControl thePlayer;
	public float timer = -1;
	Vector2 playerDirection;

	// Start is called before the first frame update
	void Start() 
	{
        
		rb = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<playerControl>();
            
	}
	
	// Called once every frame
	void Update() 
	{
		playerDirection = thePlayer.rb.position - rb.position;
		playerDirection.Normalize();
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

	

	// Handle Enemy taking damage
	void DamageEnemy(float damage) 
	{
		health -= damage;
		if (health <= 0) {
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
