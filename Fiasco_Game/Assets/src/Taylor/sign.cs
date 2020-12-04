using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign : interactableLevelObject
{
	public GameObject dialogBox;
	public Text dialogText;
	public string dialog;

    // Start is called before the first frame update
    void Start()
    {
		dialogText.text = dialog;
    }
	
	public override void Activate(){
		dialogBox.SetActive(true);
		Time.timeScale = 0;
	}
	
	public override void DeActivate(){
		dialogBox.SetActive(false);
		Time.timeScale = 1;
	}
}
