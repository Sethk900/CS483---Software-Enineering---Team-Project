using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is used to implement the difficulty feature. 
It initializes PlayerDamage and EnemyDamage to the default value of 10, and changes these values if the user presses one of the buttons in the difficulty menu. 
PlayerDamage and EnemyDamage are then used to increment or decrement the health of the player character and enemy characters, respectively.
*/


public class DifficultyImplementation : MonoBehaviour
{

	// This variable governs how much damage is done to the player each time they are hit
	public static int PlayerDamage = 10;
	// This variable governs how much an enemy is damaged when the player hits them
	public static int EnemyDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
		// Initialize PlayerDamage and EnemyDamage with default values
        PlayerDamage = 10;
		EnemyDamage = 10;
    }

    // Update is called once per frame
    void Update()
    {
  	// We don't need to do anything here-- just wait for the user to click one of the buttons in the difficulty menu.      
    }
	
	// If the user presses the easy button, the amount that the enemy damages the player will be low, but the amount that the player damages the enemies will be high. 
	public void EasyButton()
	{
		PlayerDamage = 2;
		EnemyDamage = 50;
		//Debug.Log("PlayerDamage set to "+PlayerDamage);
	}
	
	// If the user presses the normal button, then both PlayerDamage and EnemyDamage will remain at their default value of 10
	public void NormalButton()
	{
		PlayerDamage = 10;
		EnemyDamage = 10;
	}
	
	// If the player presses the hard button, the amount that the enemy damages the player will be very high, but the amount that the player damages the enemies will be low. 
	public void HardButton()
	{
		PlayerDamage = 50;
		EnemyDamage = 5;
	}
	
	// The DrBC button sets the PlayerDamage value to 0 and thereby makes the player invincible. EnemyDamage remains at its previous value, which is a default of 10. 
	public void DrBCButton()
	{
		PlayerDamage = 0;
	}
}
