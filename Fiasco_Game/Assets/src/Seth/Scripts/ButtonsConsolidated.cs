using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsConsolidated : MonoBehaviour{
	public virtual void PressButton(){
	SceneManager.LoadScene("StartScreen");
   	//Debug.Log("You initialized this button as an instance of the base class!");
   
   
}
}

public class HelpButton : ButtonsConsolidated{
	public  void PressButton(){
		SceneManager.LoadScene("HelpScreen");
	}
	
}

public class BackButton : ButtonsConsolidated{
	public  void PressButton(){
		Debug.Log("pressed back button");
       //FindObjectOfType<AudioManager>().Play("Cancel"); // - Greyson
        SceneManager.LoadScene("StartScreen");
	}
	
}

public class OptionsButton : ButtonsConsolidated{
	   public  void PressButton(){
        SceneManager.LoadScene("OptionsScreen");
	}
	}
	
public class MainMenuButton : ButtonsConsolidated{
	   public  void PressButton(){
        SceneManager.LoadScene("StartScreen");
	}
	}
	
public class ExampleOption : ButtonsConsolidated{
	public void PressButton(){
		Debug.Log("This statement is from the child class!");
	}
	}

/* Try to get this working to demonstrate static/dynamic types 
ButtonsConsolidated test = new ButtonsConsolidated();
test.PressButton();
ButtonsConsolidated test2 = new ExampleOption();
test2.PressButton();
*/
