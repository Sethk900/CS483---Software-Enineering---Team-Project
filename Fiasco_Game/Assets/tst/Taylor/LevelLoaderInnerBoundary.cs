using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;

namespace LevelLoaderTest
{
    public class LevelLoaderInnerBoundry
    {
        // A Test behaves as an ordinary method
        [Test]
        public void LevelLoaderInnerBoundryPasses()
        {
			int return_val = LevelLoader.Instance.LoadLevel(-1);
			int expected_return = 1;
			
			Assert.AreEqual(expected_return, return_val);
        }
    }
}