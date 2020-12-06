using System;
using UnityEngine;
using UnityEngine.Audio;

//Call with FindObjectOfType<GenericAudioManager>().Play("Name");
//Superclass of AudioManager, which inherits from this class.
public class GenericAudioManager : MonoBehaviour
{
    public static GenericAudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds; //See Sound.cs

    protected virtual void Awake() { //Overridden by inheritor AudioManager's Awake

    Debug.Log("GenericAudioManager awake!");
	//Initialize Sound settings
    foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
    }
    public void Play(string sound)
	{
		//Search Sound array for a sound with the passed name
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null) //Didn't find it
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		//apply given parameters, then play the sound
		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

	//TODO: Stop function
}
