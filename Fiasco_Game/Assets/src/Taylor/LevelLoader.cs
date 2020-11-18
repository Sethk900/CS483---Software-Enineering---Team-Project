using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{	
	
	public Animator transition;
	public float transitionTime = 1f;
	
	// Thread safe and lazy singleton implementation
	private LevelLoader() {}
	public static LevelLoader Instance {
		get {
			return Nested.instance;
		}
	}
	
	private class Nested {
		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static Nested() {}
		internal static readonly LevelLoader instance = new LevelLoader();
	}
	
	// Load Scene using it's Build index
	public int LoadLevel(int Build_Idx) {
		if(SceneManager.sceneCountInBuildSettings < Build_Idx || 0 > Build_Idx) { 
			Debug.Log("Invalid Build_Idx");
			return 1;
		}
		StartCoroutine(LoadLevelCoroutine(Build_Idx));
		return 0;
	}
	
	//Coroutine for loading scene with animation
	IEnumerator LoadLevelCoroutine(int Build_Idx) {
		//Play success jingle
		FindObjectOfType<AudioManager>().Play("Success"); // - Greyson
		//Play Animation
		transition.SetTrigger("Start");
	
		//Wait
		yield return new WaitForSeconds(transitionTime);
	
		//Load Scene
		SceneManager.LoadScene(Build_Idx);
	}
}