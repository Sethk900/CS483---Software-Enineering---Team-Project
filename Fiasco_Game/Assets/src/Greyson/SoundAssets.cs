using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SoundAssets : MonoBehaviour
{
    private static SoundAssets _i;

    public static SoundAssets i {
        get {
            if (_i == null) _i = Instantiate(Resources.Load<SoundAssets>("SoundAssets"));
            return _i;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
