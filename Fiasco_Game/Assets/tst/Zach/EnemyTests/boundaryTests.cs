using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class boundaryTests
    {
        int health = 10;
        // A Test behaves as an ordinary method
        [Test]
        public void lowerBoundaryTestPasses()
        {
            for(int i = 1; i <= 100; i++){
                DamageEnemy(1);
            }

            Assert.AreEqual(health, -90);
        }

        [Test]
        public void upperBoundaryTestPasses()
        {
            
            for(int i = 1; i <= 100; i++){
                addHealth(1);
            }

            Assert.AreEqual(110, health);
        }
        
        void DamageEnemy(int damage){
            health -= damage;
        }
        void addHealth(int healing){
            health += healing;
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        
    }
}
