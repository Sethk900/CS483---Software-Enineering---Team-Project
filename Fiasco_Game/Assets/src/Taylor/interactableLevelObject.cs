using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactableLevelObject : MonoBehaviour
{
	public GameObject dialogBox;
	public GameObject prompt;
	public Text dialogText;
	public string dialog;
	public bool playerInRange;
	
    // Start is called before the first frame update
    void Start()
    {
		dialogText.text = dialog;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
			if(dialogBox.activeInHierarchy){
				dialogBox.SetActive(false);
				prompt.SetActive(false);
			} else {
				dialogBox.SetActive(true);
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
}
