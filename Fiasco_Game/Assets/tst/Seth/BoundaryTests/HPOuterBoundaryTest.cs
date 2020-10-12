using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;

namespace Tests
{
    public class HPOuterBoundaryTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void HPOuterBoundaryTestSimplePasses()
        {
			HealthLogic test = new HealthLogic();
			
			int i;
			int expected_hp = 0;
			
			// This loop damages the player so much that the health value goes out of bounds
			for(i=0; i<1000; i++){
				test.DamagePlayer(1);
			}
			
			//Assert
			// Even though the loop pushed it out of bounds, the class should catch the invalid value and correct it
			Assert.AreEqual(expected_hp, test.health);
        }
		
	
    }
}
