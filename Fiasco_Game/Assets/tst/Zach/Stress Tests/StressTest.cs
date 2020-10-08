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
        private GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/Zach/Shooter/mole.prefab");
 
        [SetUp]
        public void SetUp(){
         
         SceneManager.LoadScene("Test Scene");
        
        }
        
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator StressTestPasses()
        {
            int i = 0;
            SetUp();
            
            for(i = 0; i <= 500; i++){
                
                Object.Instantiate(prefab, new Vector3(-1.5f, 4, 0), Quaternion.identity);           
            
            }

            Assert.AreEqual(i, 500);
            yield return null;
        }

    }
}
