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
        private GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/Zach/Shooter/mole/mole.prefab");
        private GameObject testObject;
        public GameObject character;
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
            SetUp();
            
            for(i = 0; i <= 1000; i++){
                
                character = GameObject.Instantiate(prefab, new Vector3(-1.5f, 4, 0), Quaternion.identity);           
                character.transform.position = Vector2.MoveTowards(character.transform.position, new Vector2(3, 5), 2 * Time.deltaTime);
            
            }

            Assert.AreEqual(i, 1000);
            yield return null;
        }

        [TearDown]
        public void removeAll(){
            
            GameObject.Destroy(testObject);
        
        }
    
    }
}
