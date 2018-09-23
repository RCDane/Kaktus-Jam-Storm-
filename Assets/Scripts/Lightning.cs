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
    AnimationCurve lightningCurve, backgroundCurve;
    [SerializeField]
    private float lightningStrikeFadeSpeed;
    [SerializeField]
    private float backgroundFadeSpeed;
    [SerializeField]
    Animation animationClip;
    bool hasFired;
    [SerializeField]
    private List<Sprite> lightningSprites;
    [SerializeField]
    private float changeSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasFired)
            return;
        else if(collision.transform.CompareTag("Player"))
        {
            //animationClip.Play();
            Color newBack = Background.color;
            newBack.a = 1;
            Background.color = newBack;
            Color newLight = lightningStrike.color;
            newLight.a = 1;
            lightningStrike.color = newLight;
            StartCoroutine(Fade(Background,backgroundFadeSpeed,backgroundCurve));
            StartCoroutine(Fade(lightningStrike, lightningStrikeFadeSpeed,lightningCurve));
            StartCoroutine(LightningSwitch(lightningStrikeFadeSpeed));
        }
    }

    IEnumerator LightningSwitch(float t)
    {
        float time = Time.timeSinceLevelLoad;
        int current = 0;
        while(Time.timeSinceLevelLoad < time + t)
        {
            lightningStrike.sprite = current == 1 ? lightningSprites[0] : lightningSprites[1];
            current = current == 1 ? 0 : 1;
            yield return new WaitForSeconds(changeSpeed);
        }
    }

    IEnumerator Fade(SpriteRenderer sprite, float t, AnimationCurve curve)
    {
        float time = Time.timeSinceLevelLoad;
        while (Time.timeSinceLevelLoad < time + t)
        {
            float timeCalc = (Time.timeSinceLevelLoad - time) / (t);
            timeCalc = curve.Evaluate(timeCalc);
            Color c = sprite.color;
            c.a = 1 - timeCalc;
            sprite.color = c;
            yield return null;
        }
        sprite.enabled = false;
    }
}
