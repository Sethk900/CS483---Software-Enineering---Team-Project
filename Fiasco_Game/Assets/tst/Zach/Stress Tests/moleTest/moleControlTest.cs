using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleControlTest : MonoBehaviour
{
	public Rigidbody2D rb;	
	public int detected;

	// Start is called before the first frame update
	void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

	
	//Handle collisions
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag.Equals("moleTest")) {
			Debug.Log("collision detected");
			detected++;
		}
	}
}
