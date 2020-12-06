using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float moveSpeed = 2f;
	public Animator animator;

	private Rigidbody2D rb;	
	public playerControl thePlayer;
	private Vector3 theScale;
	private bool flipped;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<playerControl>();
		theScale = transform.localScale;
    }
	
	/* 
	 * Called 50 times a second rather than every frame.
	 * This makes physics placed here more reliable as
	 * it isn't locked to the frame rate.
	 */
	void FixedUpdate() {
		//Move enemy
		
		if(transform.position.y < thePlayer.rb.position.y - 2)
		{
		   animator.SetBool("up", true);
		   animator.SetBool("down", false);
		   animator.SetBool("walk", false);
		} 
		else if(transform.position.y > thePlayer.rb.position.y + 2)
		{
		   animator.SetBool("up", false);
		   animator.SetBool("down", true);
		   animator.SetBool("walk", false);
		} 
		else if(transform.position.y <= thePlayer.rb.position.y + 2 && transform.position.y >= thePlayer.rb.position.y - 2 && transform.position.x > thePlayer.rb.position.x)
		{
		   animator.SetBool("up", false);
		   animator.SetBool("down", false);
		   animator.SetBool("walk", true);
		   if(flipped != true)
		   {
		   theScale = transform.localScale;
		   theScale.x *= -1;
	       flipped = true;
           transform.localScale = theScale;
		   }
		} 
		else if(transform.position.y <= thePlayer.rb.position.y + 2 && transform.position.y >= thePlayer.rb.position.y - 2 && transform.position.x < thePlayer.rb.position.x){
		   animator.SetBool("up", false);
		   animator.SetBool("down", false);
		   animator.SetBool("walk", true);
		   theScale = transform.localScale;
		   if(flipped == true)
		   {
		   flipped = false;
		   theScale.x *= -1;
		   }
		   transform.localScale = theScale;
		}
		transform.position = Vector2.MoveTowards(transform.position, thePlayer.rb.position, moveSpeed * Time.deltaTime);
		

	}
}
