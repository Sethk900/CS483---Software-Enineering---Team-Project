/*
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


		THIS CODE IS DEPRECATED. Rather than implementing the stress test as a playmode test as it is in this
		script, it is now implemented as its own scene. The logic implemented in that scene is contained within
		the BreakUI script. 

namespace Tests
{
    public class Seth_StressTest
    {
		public UIScript level1HUD;
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator Seth_StressTestWithEnumeratorPasses()
        {
			//Load the scene and instantiate the objects
			SceneManager.LoadScene("Level1"); 
			level1HUD = FindObject<UIScript>();
			public playerControl player = GetComponent<playerControl>();
			
			int i = 0;
			//Increment the score value an absurd amount of times in an attempt to break it
			for(i=0; i<100000; i++){ 
			level1HUD.score++;
			}
			
            
			Assert.IsNotNull(level1HUD); //Check whether the HUD is broken
            //yield return null;
        }
		
    }
}
*/
