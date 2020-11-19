using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LevelLoader : MonoBehaviour
{	
	// Thread safe and lazy singleton implementation
	private LevelLoader() {}
	
	public Animator transition;
	public float transitionTime = 1f;
	
	/*
	 *	Used to access the LevelLoader singleton.
	 *  Public methods can be called from other
	 *  scripts using this method in the following format
	 *  
     *  LevelLoader.Instance.LoadLevel(<<build index>>);
	 */	
	public static LevelLoader Instance {
		get {
			return Nested.instance;
		}
	}
	
	/* 
	 *  Public function used to load a level
	 *  along with a crossfade animation
	 */
	public int LoadLevel(int Build_Idx) {
		if(SceneManager.sceneCountInBuildSettings < Build_Idx || 0 > Build_Idx) { 
			Debug.Log("Invalid Build_Idx");
			return 1;
		}
		StartCoroutine(LoadLevelCoroutine(Build_Idx));
		return 0;
	}
	
	/*
	 * Coroutine used to play level animation,
	 * wait for transition time, and then load
	 * a new level
	 */
	private IEnumerator LoadLevelCoroutine(int Build_Idx) {
		//Play Animation
		transition.SetTrigger("Start");
	
		//Wait
		yield return new WaitForSeconds(transitionTime);
	
		//Load Scene
		SceneManager.LoadScene(Build_Idx);
	}
	
	/*
	 * Private class used to implement 
	 * LevelLoader as a singleton
	 */
	private class Nested {
		// internal allows Nested to access private constructor
		static Nested() {}
		internal static readonly LevelLoader instance = new LevelLoader();
	}
}