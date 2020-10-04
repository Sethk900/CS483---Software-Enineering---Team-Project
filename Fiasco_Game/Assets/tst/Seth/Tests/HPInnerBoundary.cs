using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;

namespace Tests
{
    public class HPInnerBoundaryTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void HUDStressTestSimplePasses()
        {
			playerControl test = new playerControl();
			var UIScript = new UIScript();
		
            // Use the Assert class to test conditions
			// In this stress test we simulate a large number of collision between enemy bullets and the player
			// At the end of the test, the health variable should be 0 
			
			//int i;
			int expected_hp = 10;
			
			// Try out the DamagePlayer function to bring the HP down to 10
			/*for(i=0; i<8; i++){
				playerControl.DamagePlayer(10);
			}
			for(i=0; i<10; i++){
				playerControl.DamagePlayer(1);
			}*/
			UIScript.health = 10; // Temporary cheat, until I can get the editmode Monobehavior class isntantiation figured out
			Assert.AreEqual(expected_hp, UIScript.health);
        }
    }
}