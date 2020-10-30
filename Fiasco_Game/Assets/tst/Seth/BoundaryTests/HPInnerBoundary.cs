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
        public void HPInnerBoundaryTestSimplePasses()
        {
			HealthLogic test = new HealthLogic();
			
			// At the end of the test, the health variable should be 10
			int i;
			int expected_hp = 10;
			
			for(i=0; i<5; i++){ //50 damage
				test.DamagePlayer(10);
			}
			for(i=0; i<5; i++){ //25 damage
				test.DamagePlayer(5);
			}
			for(i=0; i<15; i++){ // 15 damage
				test.DamagePlayer(1);
			}
			
			Assert.AreEqual(UIScript.health, expected_hp);
        }
		
	
    }
}