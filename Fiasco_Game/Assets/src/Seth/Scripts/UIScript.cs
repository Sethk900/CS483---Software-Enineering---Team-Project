  
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
	
    // Start is called before the first frame update
    void Start()
    {
        HUD = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
	// Constantly update the HUD
        HUD.text = "Score: " + score + " Health: " + health;

		// Later we will implement logic here to load the death screen
		if(health==0){
			HUD.text = "You died :(";
		}
    }
}