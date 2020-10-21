using UnityEngine.Audio;
using System;
using UnityEngine;

//Call with FindObjectOfType<AudioManager>().Play("Name");
public class audioManager : genericAudioManager //persistent version of genericAudioManager
{

	protected override void Awake()
	{
		base.Awake();
		Debug.Log("AudioManager awake!");

		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
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
