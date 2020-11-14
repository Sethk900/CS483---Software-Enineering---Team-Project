using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{

    // These public variables allow us to track health and score
    public static int score = 0;
    public static int health = 100;
    Text HUD;
	GameObject[] pauseObjects;

	// Implement the class as a Singleton. There will only be one UI. 
	private UIScript() { }
	public static UIScript Instance {
	get {
	return Nested.instance;
		}
	}
	private class Nested {
		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static Nested() { }
		internal static readonly UIScript instance = new UIScript();
	}

	
    // Start is called before the first frame update
    void Start()
    {
		// Initialize the Heads Up Display
        HUD = GetComponent<Text>();
		
		//Initialize the objects that will be hidden until the game is paused (i.e., the objects that make up the pause menu)
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused(); //At the beginning of the scene, hide all of the objects on the pause menu
    }

    // Update is called once per frame
    void Update()
    {
		// Constantly update the HUD
        HUD.text = "Score: " + score + " Health: " + health;

		// Check if the player paused the game: if they have, show all the objects associated with the pause sreen, and set timescale to 0. 
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

		// Later we will implement logic here to load the death screen  <---- Actually, this is deprecated: the deathscreen is loaded via playerDeath in the playerControl script
		if(health==0){
			HUD.text = "You died :(";
		}
    }

	// This function iterates through the list of game objects tagged as "showOnPause" and hides them (i.e. sets active to false)	
	void hidePaused()
 {
     foreach (GameObject p in pauseObjects)
     {
         p.SetActive(false);
     }
 }
 
	// This function does the opposite of hidePaused(): it iterates through the array of pause menu objects and shows them on screen (i.e. sets active to true)
 	void showPaused()
 {
     foreach (GameObject p in pauseObjects)
     {
         p.SetActive(true);
     }
 }
}
