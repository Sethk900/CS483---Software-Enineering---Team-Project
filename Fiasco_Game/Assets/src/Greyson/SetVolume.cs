using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    //public Slider slider;

    /*void Start() {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        // TODO: Save and set values for ALL sliders
    }*/
    public void SetLevelMusic (float sliderValue) {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SetLevelSFX (float sliderValue) {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelMaster (float sliderValue) {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }
}
