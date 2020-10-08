using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float moveSpeed = 2f;
	public Animator animator;

	private Rigidbody2D rb;	
	public playerControl thePlayer;
	
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<playerControl>();
    }
	
	/* 
	 * Called 50 times a second rather than every frame.
	 * This makes physics placed here more reliable as
	 * it isn't locked to the frame rate.
	 */
	void FixedUpdate() {
		//Move enemy
		if(transform.position.y > thePlayer.rb.position.y){
		   animator.SetBool("up", true);
		   animator.SetBool("down", false);
		   animator.SetBool("right", false);
		   animator.SetBool("left", false);
		} else if(transform.position.y < thePlayer.rb.position.y){
		   animator.SetBool("up", false);
		   animator.SetBool("down", true);
		   animator.SetBool("right", false);
		   animator.SetBool("left", false);
		}
		if(transform.position.y == thePlayer.rb.position.y && transform.position.x < thePlayer.rb.position.x){
			animator.SetBool("up", false);
		   animator.SetBool("down", false);
		   animator.SetBool("right", true);
		   animator.SetBool("left", false);
		} else if(transform.position.y == thePlayer.rb.position.y && transform.position.x > thePlayer.rb.position.x){
			animator.SetBool("up", false);
		   animator.SetBool("down", false);
		   animator.SetBool("right", false);
		   animator.SetBool("left", true);
		}
		transform.position = Vector2.MoveTowards(transform.position, thePlayer.rb.position, moveSpeed * Time.deltaTime);
		

	}
}
