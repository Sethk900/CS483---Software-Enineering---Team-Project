using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject thePlayer;
	public Vector3 offset = new Vector3(0,0,-1);

    // Update is called once per frame
    void FixedUpdate()
    {
        if (thePlayer) {
			transform.position = new Vector3( thePlayer.transform.position.x + offset.x,
											  thePlayer.transform.position.y + offset.y,
 											  thePlayer.transform.position.z + offset.z);
		}
   }
}
