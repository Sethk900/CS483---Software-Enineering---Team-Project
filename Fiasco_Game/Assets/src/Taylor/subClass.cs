using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subClass : interactableLevelObject
{
	public LevelLoader loader;
	
	public override void Activate(){
		loader.LoadLevel(2);
		Debug.Log("Subclass");
	}
}
