using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;

namespace Taylor_Test
{
    public class LvlLoaderInnerBoundaryTest
    {
        [Test]
        public void LvlLoaderInnerBoundaryTestPasses()
        {
			LevelLoader test = new LevelLoader();
			
			int expected_return = 1;
			int return_val = test.LoadLevel(-1);
			
			Assert.AreEqual(expected_return, return_val);
        }
		
    }
}