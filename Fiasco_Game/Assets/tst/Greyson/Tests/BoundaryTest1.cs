using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Audio;

namespace Tests
{
    public class BoundaryTest1
    {
        public AudioMixer mixer;
        float expectedmaxvol = 1f; //this is what the max vol is defined as in the Editor
        float value;
        [Test]
        public void BoundaryTest1SimplePasses()
        {
            float i;
            for(i = 0.1f; i < 2; i += .1f) {
                mixer.SetFloat("MasterVol", Mathf.Log10(i) * 20);
            }
        bool result = mixer.GetFloat("MasterVol", out float value);
        expectedmaxvol = Mathf.Log10(expectedmaxvol) * 20;
        Assert.AreEqual(expectedmaxvol, value); 
        }

    }
}
