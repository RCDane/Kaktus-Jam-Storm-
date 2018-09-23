using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Player")) {
            Debug.Log("Taking a swim");
            var rend = GetComponent<SpriteRenderer>();
            var fade = StartCoroutine(FadeTo(rend,0f,0.5f));

            var fog = GameObject.FindGameObjectWithTag("Fog");
            // .material getter clones the material, 
            // so cache this copy in a member variable so we can dispose of it when we're done.
            var _myMaterial = fog.GetComponent<SpriteRenderer>();

            var player = GameObject.FindGameObjectWithTag("Player");
            var _pmat = player.GetComponent<SpriteRenderer>();

            // Start a coroutine to fade the material to zero alpha over 3 seconds.
            // Caching the reference to the coroutine lets us stop it mid-way if needed.
            var _currentFade = StartCoroutine(FadeTo(_myMaterial,1f,0.5f));
            var _pfade = StartCoroutine(FadeTo(_pmat,0f,0.5f));

            //var player = GameObject.FindGameObjectWithTag("Player");
            //player.gameObject.transform.position = new Vector3(-193.07f,-15.27f);
            StartCoroutine(ExecuteAfterTime(2f));

        }
        

    }

    IEnumerator ExecuteAfterTime(float time) {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        var player = GameObject.FindGameObjectWithTag("Player");
        player.gameObject.transform.position = new Vector3(-193.07f,-15.49f);
        
        var _currentFade = StartCoroutine(FadeIn(1f));
    }

    IEnumerator FadeIn(float time) {
        yield return new WaitForSeconds(time);
        
        var rend = GetComponent<SpriteRenderer>();
        var fade = StartCoroutine(FadeTo(rend,1f,2f));

        var fog = GameObject.FindGameObjectWithTag("Fog");
        // .material getter clones the material, 
        // so cache this copy in a member variable so we can dispose of it when we're done.
        var _myMaterial = fog.GetComponent<SpriteRenderer>();

        var player = GameObject.FindGameObjectWithTag("Player");
        var _pmat = player.GetComponent<SpriteRenderer>();

        // Start a coroutine to fade the material to zero alpha over 3 seconds.
        // Caching the reference to the coroutine lets us stop it mid-way if needed.
        var _currentFade = StartCoroutine(FadeTo(_myMaterial,0f,2f));
        var _pfade = StartCoroutine(FadeTo(_pmat,1f,0.5f));
    }


    // Define an enumerator to perform our fading.
    // Pass it the material to fade, the opacity to fade to (0 = transparent, 1 = opaque),
    // and the number of seconds to fade over.
    IEnumerator FadeTo(SpriteRenderer material,float targetOpacity,float duration) {

        // Cache the current color of the material, and its initiql opacity.
        Color color = material.color;
        float startOpacity = color.a;

        // Track how many seconds we've been fading.
        float t = 0;

        while(t < duration) {
            // Step the fade forward one frame.
            t += Time.deltaTime;
            // Turn the time into an interpolation factor between 0 and 1.
            float blend = Mathf.Clamp01(t / duration);

            // Blend to the corresponding opacity between start & target.
            color.a = Mathf.Lerp(startOpacity,targetOpacity,blend);

            // Apply the resulting color to the material.
            material.color = color;

            // Wait one frame, and repeat.
            yield return null;
        }
    }
}
