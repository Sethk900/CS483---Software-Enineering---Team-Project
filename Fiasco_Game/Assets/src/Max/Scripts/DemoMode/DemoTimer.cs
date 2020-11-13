using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoTimer : MonoBehaviour
{
    public float timer = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1")){
            timer = 15;
        }
        if (timer <= 0){
            SceneManager.LoadScene("DemoMode");
        }
    }
}
