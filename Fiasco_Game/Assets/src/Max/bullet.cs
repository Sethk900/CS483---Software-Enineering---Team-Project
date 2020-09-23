using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D col) {
		// Ignore collisions for objects with specific tags
		if (col.gameObject.tag  == "Pit") {
			Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		} else {
			Destroy(gameObject);
		}
	}
}
