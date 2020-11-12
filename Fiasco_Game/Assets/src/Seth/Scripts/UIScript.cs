  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
This script implemnts the UI. It tracks the various items that make up the HUD and UI and updates them once per frame. */

public class UIScript : MonoBehaviour
{

    // These public variables allow us to track health and score
    public static int score = 0;
    public static int health = 100;
    Text HUD;
	GameObject[] pauseObjects; // This array contains all of the objects that we want to display on the screen when the player pauses the game
	
    // Start is called before the first frame update
    void Start()
    {
		// Initialize the Heads Up Display
        HUD = GetComponent<Text>();
		
		//Initialize the objects that will be hidden until the game is paused (i.e., the objects that make up the pause menu)
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause"); // Populate the array of objects that appear in the pause screen
		hidePaused(); // Hide all of the objects that appear on the pause menu, until the player presses p
    }

    // Update is called once per frame
    void Update()
    {
		// Constantly update the HUD
        HUD.text = "Score: " + score + " Health: " + health;

		// Check if the player paused the game. If they have, change the timescale and show all of the objects that should appear on the pause screen. 
		if(Input.GetKeyDown(KeyCode.P)){
		if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}

		// Later we will implement logic here to load the death screen
		if(health==0){
			HUD.text = "You died :(";
		}
    }
	

	void hidePaused() // This function iterates through the array of objects that should appear on the pause screen and hides them (i.e. sets active to false)
 {
     foreach (GameObject p in pauseObjects)
     {
         p.SetActive(false);
     }
 }
 
 	void showPaused() // This function iterates through the array of objects that should appear on the pause screen and shows them (i.e. sets active to true)
 {
     foreach (GameObject p in pauseObjects)
     {
         p.SetActive(true);
     }
 }
}
