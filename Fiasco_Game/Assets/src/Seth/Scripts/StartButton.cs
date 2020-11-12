using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
While most of the button code is now shifted to the ButtonsConsolidated script, this one is a little special.
Since it initializes the UI values, I decided to leave it as its own script.
*/

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	// As soon as the user presses the start button, the UI values (health and score) are initialized.		
	public void PressStartButton(){
        UIScript.score = 0;
        UIScript.health = 100;
        SceneManager.LoadScene("Level 1");
	}
	
	// End the application if the player presses the quit button on the pause menu
	public void PressQuitButton(){
		Application.Quit();
	}
}
