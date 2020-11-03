using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;
namespace Tests
{
    public class HUDStressTest
    {
		//public playerControl testplayer;
		//public UIScript testUI;
        // A Test behaves as an ordinary method
        [Test]
        public void HUDStressTestSimplePasses()
        {
			HealthLogic test = new HealthLogic();
			//GameObject testobject = new GameObject();
			//testobject.AddComponent(playerControl);
			//var playerControl = new playerControl();
			//var UIScript = new UIScript();
			//testplayer = GameObject.FindObjectOfType<playerControl>();
            // Use the Assert class to test conditions
			// In this stress test we simulate a large number of collision between enemy bullets and the player
			// At the end of the test, the health variable should be 0 
			
			int i;
			int expected_hp = 0;
			
			for(i=0; i<1000; i++){
				test.DamagePlayer(1);
				//testobject.DamagePlayer(1);
				//testplayer.DamagePlayer(1);
				//playerControl.DamagePlayer(1);
			}
			//UIScript.health=0;
			Assert.AreEqual(expected_hp, test.health);
			//Assert.AreEqual(expected_hp, testplayer.health);
        }
		
	
    }
}

