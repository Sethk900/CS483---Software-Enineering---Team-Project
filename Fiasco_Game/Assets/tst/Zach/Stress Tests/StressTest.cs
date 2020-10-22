using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
     



namespace Tests
{
    public class StressTest
    {      
        private GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/tst/Zach/Stress Tests/moleTest/moleTest.prefab");
        private GameObject testObject;
        public GameObject character;
        private int collisionsDetected;
        [SetUp]
        public void SetUp(){
         
           testObject = GameObject.Instantiate(new GameObject());
        
        }
        
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator StressTestPasses()
        {
            int i = 0;
            moleControlTest moleVars;
            SetUp();
            
            for(i = 0; i < 1000; i++){
                
                character = GameObject.Instantiate(prefab, new Vector3(-1.5f, 4, 0), Quaternion.identity);           
                moleVars = character.GetComponent<moleControlTest>();
                collisionsDetected = moleVars.detected + collisionsDetected;
            
            }
            

            Assert.AreEqual(collisionsDetected, 1000);
            yield return null;
        }

        [TearDown]
        public void removeAll(){
            
            GameObject.Destroy(testObject);
        
        }
    
    }
}
