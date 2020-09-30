using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
	
	public float moveSpeed = 5f;
	public float crosshairDistance = 2f;
//	public float health = 10f;
	public float bulletSpeed = 20.0f;

	public Rigidbody2D rb;
	public GameObject bulletPrefab;
	public GameObject crosshair;
	public Camera mainCam;
	
	bulletControl bcInst;
	
	Vector2 movementDir;
	Vector2 lookDir;
	Vector2 mousePos;
	Quaternion _facing;
	
	void Start() {
		bcInst = GetComponent<bulletControl>();
	}
	
    // Update is called once per frame
    void Update() {
        movementDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		
		mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
		
		if (Input.GetButtonDown("Fire1")) {
			bcInst.Shoot(rb.position,crosshair.transform.localPosition, bulletSpeed, bulletPrefab);
		}
    }
	
	/* 
	 * Called 50 times a second rather than every frame.
	 * This makes physics more reliable as it isn't locked
	 * to the frame rate.
	 */
	void FixedUpdate() {
		// Position is updated here, using Time.fixedDeltaTime keeps movement consistent
		rb.MovePosition(rb.position + movementDir * moveSpeed * Time.fixedDeltaTime);
		
		// Shooting angle is updated here
		lookDir = mousePos - rb.position;
		Aim();
	}
	
	void Aim() {
			crosshair.transform.localPosition = lookDir.normalized * crosshairDistance;
	}
		
	// Handle collisions
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag.Equals("EnemyBullet")) {
			DamagePlayer(1);
		}
	}
	
		// Handle Enemy taking damage
	void DamagePlayer(int damage) {
		//health -= damage;
		UIScript.health -= damage;
		if (UIScript.health <= 0) {
			PlayerDeath();
		}
	}
	
	// Function called on player death
	void PlayerDeath() {
		Destroy(gameObject);
	}
}
