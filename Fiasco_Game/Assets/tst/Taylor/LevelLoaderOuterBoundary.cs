using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;
using UnityEngine.SceneManagement;

namespace LevelLoaderTest
{
    public class LevelLoaderOuterBoundry
    {
        // A Test behaves as an ordinary method
        [Test]
        public void LevelLoaderOuterBoundryPasses()
        {
			int return_val = LevelLoader.Instance.LoadLevel(SceneManager.sceneCountInBuildSettings + 1);
			int expected_return = 1;
			
			Assert.AreEqual(expected_return, return_val);
        }
    }
}