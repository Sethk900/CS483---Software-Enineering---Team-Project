using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : interactableLevelObject
{
	public LevelLoader loader;
	public int nextLevel;
	
	public override void Activate(){
		loader.LoadLevel(nextLevel);
		Debug.Log("Subclass");
	}
}
