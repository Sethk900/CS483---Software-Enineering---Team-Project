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
        // A Test behaves as an ordinary method
        [Test]
        public void HUDStressTestSimplePasses()
        {
			var playerControl = new playerControl();
			var UIScript = new UIScript();
		
            // Use the Assert class to test conditions
			// In this stress test we simulate a large number of collision between enemy bullets and the player
			// At the end of the test, the health variable should be 0 
			
			int i;
			int expected_hp = 0;
			
			for(i=0; i<1000; i++){
				playerControl.DamagePlayer(1);
			}
			Assert.AreEqual(expected_hp, UIScript.health);
        }
    }
}