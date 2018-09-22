using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

	public AudioClip SoundClip;
	public bool HasPlayedSoundEffect = false;

	// Use this for initialization
	void Start ()
	{
		GetComponent<AudioSource>().playOnAwake = false;
		GetComponent<AudioSource>().clip = SoundClip;
	}
	
	void OnTriggerEnter2D()
	{
		if(HasPlayedSoundEffect == false)
		{
			HasPlayedSoundEffect = true;
			GetComponent<AudioSource> ().Play();
		}
	}
}
