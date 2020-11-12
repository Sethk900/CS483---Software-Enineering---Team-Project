using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactableLevelObject : MonoBehaviour
{
	public GameObject prompt;
	bool playerInRange;
	bool objectActive;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
			if(objectActive){
				DeActivate();
				objectActive = false;
			} else {
				Activate();
				objectActive = true;
			}
		}
    }
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			playerInRange = true;
			prompt.SetActive(true);
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("Player")){
			playerInRange = false;
			prompt.SetActive(false);
		}
	}
	
	public virtual void Activate(){
		Debug.Log("Activate");
	}
	
	public virtual void DeActivate(){
		Debug.Log("DeActivate");
	}
}
