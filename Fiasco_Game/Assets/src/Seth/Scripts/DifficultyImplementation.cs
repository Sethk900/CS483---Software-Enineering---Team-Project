using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }
	
	public void EasyButton()
	{
		PlayerDamage = 2;
		EnemyDamage = 50;
		//Debug.Log("PlayerDamage set to "+PlayerDamage);
	}
	
	public void NormalButton()
	{
		PlayerDamage = 10;
		EnemyDamage = 10;
	}
	
	public void HardButton()
	{
		PlayerDamage = 50;
		EnemyDamage = 5;
	}
	
	public void DrBCButton()
	{
		PlayerDamage = 0;
	}
}
