using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager {

    public enum Sound { //all the sounds that can be played, with files defined in the Editor
        tempPlayerShoot,
        tempPlayerWalk,
        tempEnemyHit
    }

    private static Dictionary<Sound, float> soundTimerDictionary;

    public static void Initialize() { //call in script that triggers tempPlayerWalk
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.tempPlayerWalk] = 0f;
    }

    private static bool CanPlaySound(Sound sound) {
        switch (sound) {
            default:
                return true;
            case Sound.tempPlayerWalk: //don't want walk sounds to be triggered every frame
                if  (soundTimerDictionary.ContainsKey(sound)) {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimerMax = .05f;
                    if (lastTimePlayed + playerMoveTimerMax < Time.time) {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return true;
                }
                //break
        }
    }

    public static void PlaySound(Sound sound) {
        if (CanPlaySound(sound)) {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    private static AudioClip GetAudioClip(Sound sound) {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.soundAudioClipArray) {
            if (soundAudioClip.sound == sound) {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}