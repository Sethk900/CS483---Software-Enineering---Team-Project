using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

/*
This script is fairly simple. 
Once we start the test scene, it instantiates itself and starts to increment the health and score values.
Once either the health or the score value rolls over to a negative value, it loads the death screen and 
logs a statement telling us how long it took to break the UI.
*/

public class BreakUI : MonoBehaviour
{
	public int k = 0;
	public int i = 0;
	public int sum = 0;
	public int IncrementValue=1; //Update IncrementValue to govern how much we increment the health and score values by
    // Start is called before the first frame update
    void Start()
    {
	// Initialize the health and score values for the instantiation of the UIScript class
        UIScript.health=0;
		UIScript.score=0;
    }

    // Update is called once per frame
    void Update()
    {
		// Every 60 frames, double the value by which we increment the sum
		if ((k%60)==0) {IncrementValue = IncrementValue*2;}
		k++;
      		i++;

		// Add the sum to the health and score values every single frame
	  	UIScript.health+=sum;
		UIScript.score+=sum;
		// Increase the sum by IncrementValue every frame
		sum+=IncrementValue;

		// If the health rolls over to a negative value, load the death screen and log a message with details
		if(UIScript.health<0){
			Debug.Log("Invalid negative value detected for health after incrementing health by "+sum+" points in"+i+" frames.");
			SceneManager.LoadScene("DeathScreen");
			}
		// If the score rolls over to a negative value, load the death screen and log a message with details
		if(UIScript.score<0){
			Debug.Log("Invalid negative value detected for score after incrementing score by "+sum+" points in "+i+" frames.");
	   		SceneManager.LoadScene("DeathScreen");
				}
    }
}

