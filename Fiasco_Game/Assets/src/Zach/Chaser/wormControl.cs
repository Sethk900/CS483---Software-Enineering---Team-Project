using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class wormControl : MonoBehaviour
{
	public Animator animator;
	//Enemy Parameters
	public float health = 10f;

	public Rigidbody2D rb;	
	public playerControl thePlayer;

	Vector2 playerDirection;

	// Start is called before the first frame update
	void Start() {
        
		rb = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<playerControl>();
            
	}
	
	// Called once every frame
	void Update() {
		playerDirection = thePlayer.rb.position - rb.position;
		playerDirection.Normalize();
		animator.SetBool("damaged", false);
	}
	
	/* 
	* Called 50 times a second rather than every frame.
	* This makes physics placed here more reliable as
	* it isn't locked to the frame rate.
	*/
	void FixedUpdate () {
		
        
	}
	
	//Handle collisions
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag.Equals("PlayerBullet")) {
			DamageEnemy(2.5f);
			animator.SetBool("damaged", true);
		}
	}

	

	// Handle Enemy taking damage
	void DamageEnemy(float damage) {
		health -= damage;
		if (health <= 0) {
			EnemyDeath();
			UIScript.score+=1; //Increment the score
		}
	}
	
	// Handle Enemy Death
	void EnemyDeath() {
		Destroy(gameObject);
	}
}
