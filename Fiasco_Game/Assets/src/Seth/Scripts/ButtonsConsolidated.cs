using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
This script implements the button classes in a "Unity-style" prototype pattern. In a conventional prototype pattern, there would be some sort of clone() method that would
be used to instantiate new copies of the prototype base class dynamically as they are needed. In Unity, however, this is not possible, because all classes are pre-compiled,
which means that we can't use clone() methods dynamically. Instead, I manually copy-pasted the code that I need from the base class and changed only one attribute (the new 
scene name) for each of the child classes. As a result, I preserve the idea and core functionality of a prototype pattern without actually haveing to use a clone() method.
*/

// This is the base class. It loads the start screen. 
public class ButtonsConsolidated : MonoBehaviour{
	public virtual void PressButton(){  // Notice the virtual keyword here. This means that PressButton() binds to the dynamic type for a given instantiation. 
	SceneManager.LoadScene("StartScreen");
   	//Debug.Log("You initialized this button as an instance of the base class!");
   
   
}
}

// This subclass, a clone of the ButtonsConsolidated prototype, loads the help screen
public class HelpButton : ButtonsConsolidated{
	public  void PressButton(){
		SceneManager.LoadScene("HelpScreen");
	}
	
}

// This subclass, a clone of the ButtonsConsolidated prototype, loads the start screen
public class BackButton : ButtonsConsolidated{
	public  void PressButton(){
		Debug.Log("pressed back button");
       //FindObjectOfType<AudioManager>().Play("Cancel"); // - Greyson
        SceneManager.LoadScene("StartScreen");
	}
	
}

// This subclass, a clone of the ButtonsConsolidated prototype, loads the options screen
public class OptionsButton : ButtonsConsolidated{
	   public  void PressButton(){
        SceneManager.LoadScene("OptionsScreen");
	}
	}
	
// This subclass, a clone of the ButtonsConsolidated prototype, is used for the main menu button on our game's pause menu 
public class MainMenuButton : ButtonsConsolidated{
	   public  void PressButton(){
        SceneManager.LoadScene("StartScreen");
	}
	}
	
// This subclass, a prototype of the ButtonsConsolidated prototype, is an example that I used throughout the development and testing process
public class ExampleOption : ButtonsConsolidated{
	public void PressButton(){
		Debug.Log("This statement is from the child class!");
	}
	}

/* This is some sample code to demonstrate static and dynamic binding.
It can't actually be run in Unity, because methods can't be called in this namespace, but if you'd like you can copy the classes above into a C# script with this code and run it to see static/dynamic binding.
// ButtonsConsolidated is both the static and dynamic type, so PressButton() will be bound to the declaration from ButtonsConsolidated
ButtonsConsolidated test = new ButtonsConsolidated();
test.PressButton(); // Loads the start screen
// ButtonsConsolidated is the static type and ExampleOption is the dynamic type. Since PressButton() is declared with the virtual keyword in ButtonsConsolidated, for this instance it binds to the dynamic type--
// that is, the declaration in ExampleOption
ButtonsConsolidated test2 = new ExampleOption();
test2.PressButton();  // Debug statement; "This statement is from the child class!"
*/
