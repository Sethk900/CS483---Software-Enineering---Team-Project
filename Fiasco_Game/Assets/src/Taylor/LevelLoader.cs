using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
	// Build indexes that map to scenes
	// Must be manually updated
	public int Lvl_1_Build_Idx = 0;
	public int Lvl_2_Build_Idx = 1;
	
	public Animator transition;
	
	public float transitionTime = 1f;
	
    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Debug Next")) {
			LoadLevel(Lvl_2_Build_Idx);
		}
    }
	// Load Scene using it's Build index
	public int LoadLevel(int Build_Idx) {
		if(Build_Idx > SceneManager.sceneCountInBuildSettings ||
		   Build_Idx < 0) {
			Debug.Log("Invalid Command, build inded out of range");
			return 1;
		}
		StartCoroutine(LoadLevelCoroutine(Build_Idx));
		return 0;
	}
	
	public int LoadNextLevel() {
		if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			return 0;
		} else {
			Debug.Log("Invalid Command, in last scene");
			return 1;
		}
	}
	//Coroutine for loading scene
	IEnumerator LoadLevelCoroutine(int Build_Idx) {
		//Play Animation
		transition.SetTrigger("Start");
	
		//Wait
		yield return new WaitForSeconds(transitionTime);
	
		//Load Scene
		SceneManager.LoadScene(Build_Idx);
	}
}
