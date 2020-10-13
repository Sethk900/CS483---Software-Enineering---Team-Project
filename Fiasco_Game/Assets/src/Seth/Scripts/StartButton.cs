using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	
		
	public void PressStartButton(){
        UIScript.score = 0;
        UIScript.health = 100;
        SceneManager.LoadScene("Level 1");
	}
	
	public void PressQuitButton(){
		Application.Quit();
	}
}
