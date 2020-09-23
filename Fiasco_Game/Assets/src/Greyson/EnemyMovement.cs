using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float moveSpeed = 2f;

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
		transform.position = Vector2.MoveTowards(transform.position, thePlayer.rb.position, moveSpeed * Time.deltaTime);
	}
}
