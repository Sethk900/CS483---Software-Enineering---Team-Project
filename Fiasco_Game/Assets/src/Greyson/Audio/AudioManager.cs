using UnityEngine.Audio;
using System;
using UnityEngine;

//Call with FindObjectOfType<AudioManager>().Play("Name");
//Singleton, persistent subclass of GenericAudioManager - not destroyed when changing scenes
public class AudioManager : GenericAudioManager 
{

	protected override void Awake() //This is called instead of genericAudioManager Awake
	//not quite dynamic binding because Unity is weird about it, but it works
	{
		base.Awake(); //calls genericAudioManager Awake anyways
		Debug.Log("AudioManager awake!");

		//Enforces singleton-ness
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else //Stops destruction of AudioManager between scenes (lets sounds play between loads)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		/*
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
		*/
	}

}
