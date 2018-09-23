using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
    BoxCollider2D collider;
    [SerializeField]
    private SpriteRenderer lightningStrike;
    [SerializeField]
    private SpriteRenderer Background;
    [SerializeField]
    private float lightningStrikeFadeSpeed;
    [SerializeField]
    private float backgroundFadeSpeed;

    bool hasFired;
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasFired)
            return;
        else if(collision.transform.CompareTag("Player"))
        {
            Color newBack = Background.color;
            newBack.a = 1;
            Background.color = newBack;
            Color newLight = lightningStrike.color;
            newLight.a = 1;
            lightningStrike.color = newLight;
            StartCoroutine(Fade(Background,backgroundFadeSpeed));
            StartCoroutine(Fade(lightningStrike, lightningStrikeFadeSpeed));
        }
    }


    IEnumerator Fade(SpriteRenderer sprite, float t)
    {
        float time = Time.timeSinceLevelLoad;
        while (Time.timeSinceLevelLoad < time + t)
        {
            float timeCalc = (Time.timeSinceLevelLoad - time) / (t);
            Color c = sprite.color;
            c.a = 1 - timeCalc;
            sprite.color = c;
            yield return null;
        }
        sprite.enabled = false;
    }
}
