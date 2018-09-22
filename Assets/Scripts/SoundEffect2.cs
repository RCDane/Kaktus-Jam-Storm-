using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect2 : MonoBehaviour {

	public AudioClip SoundClip;
	public float fadingTime;
	public float maxVolume;
	AudioSource source;
	// Use this for initialization
	void Start ()
	{
		source = GetComponent<AudioSource>();
		source.playOnAwake = false;
		source.clip = SoundClip;
	}
	bool fadingIn;
	float currentVolume;
	void Update(){
		if(fadingIn)
		{
			currentVolume += Time.deltaTime / fadingTime;
			if(currentVolume > maxVolume)
				currentVolume = maxVolume;
			source.volume = currentVolume;
		}
		else
		{
			currentVolume -= Time.deltaTime / fadingTime;
			if(currentVolume < 0)
				currentVolume = 0;
			source.volume = currentVolume;
		}
	}
	void OnTriggerEnter2D(Collider2D Collision)
	{
		if (Collision.transform.CompareTag("Player"))
		{
			fadingIn = true;
			GetComponent<AudioSource> ().Play();
			Debug.Log(transform.name);
		}
	}

	void OnTriggerExit2D(Collider2D Collision)
	{
		if (Collision.transform.CompareTag("Player"))
		{
			fadingIn = false;
			// GetComponent<AudioSource>().Stop();	
			Debug.Log("Exit");
		}
	}
}
