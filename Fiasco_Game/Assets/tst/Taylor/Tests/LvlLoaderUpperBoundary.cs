using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;
using UnityEngine.SceneManagement;

namespace Taylor_Test
{
    public class LvlLoaderUpperBoundaryTest
    {
        [Test]
        public void LvlLoaderUpperBoundaryTestPasses()
        {
			LevelLoader test = new LevelLoader();
			
			int expected_return = 1;
			int return_val = test.LoadLevel(SceneManager.sceneCountInBuildSettings + 1);
			
			Assert.AreEqual(expected_return, return_val);
        }
		
    }
}
