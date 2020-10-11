using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Audio;

namespace Tests
{
    public class BoundaryTest2
    {
        public AudioMixer mixer;
        float expectedmaxvol = 0.0001f;
        float value;
        [Test]
        public void BoundaryTest2SimplePasses()
        {
            float i;
            for(i = .9f; i > -2; i -= .1f) {
                mixer.SetFloat("MasterVol", Mathf.Log10(i) * 20);
            }
        bool result = mixer.GetFloat("MasterVol", out float value);
        expectedmaxvol = Mathf.Log10(expectedmaxvol) * 20;
        Assert.AreEqual(expectedmaxvol, value); 
        }

    }
}