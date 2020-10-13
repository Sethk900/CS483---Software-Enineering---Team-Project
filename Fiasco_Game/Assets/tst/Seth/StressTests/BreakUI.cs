using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
	  	UIScript.health+=100;
		UIScript.score+=1000000;
	   
    }
}
