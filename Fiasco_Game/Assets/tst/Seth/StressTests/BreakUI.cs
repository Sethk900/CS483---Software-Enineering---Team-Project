using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class BreakUI : MonoBehaviour
{
	public int k = 0;
	public int i = 0;
	public int sum = 0;
	public int IncrementValue=1; //Update IncrementValue to govern how much we increment the health and score values by
    // Start is called before the first frame update
    void Start()
    {
        UIScript.health=0;
		UIScript.score=0;
    }

    // Update is called once per frame
    void Update()
    {
		if ((k%60)==0) {IncrementValue = IncrementValue*2;}
		k++;
      	i++;
	  	UIScript.health+=sum;
		UIScript.score+=sum;
		sum+=IncrementValue;
		if(UIScript.health<0){
			Debug.Log("Invalid negative value detected for health after incrementing health by "+sum+" points in"+i+" frames.");
			SceneManager.LoadScene("DeathScreen");
			}
		if(UIScript.score<0){
			Debug.Log("Invalid negative value detected for score after incrementing score by "+sum+" points in "+i+" frames.");
	   		SceneManager.LoadScene("DeathScreen");
				}
    }
}

