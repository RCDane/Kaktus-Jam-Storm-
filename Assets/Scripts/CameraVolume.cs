using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraVolume : MonoBehaviour {
    private BoxCollider2D volume;
    public float cameraSize;
    public float interpolationTime = 5;
    CinemachineVirtualCamera cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform != null && collision.transform.CompareTag("Player"))
        {
            interpolationDirection = cameraSize - startSize;
            cam = Camera.main.transform.GetComponent<CinemachineVirtualCamera>();
            startTime = Time.timeSinceLevelLoad;
            interpolating = true;
            startSize = cam.m_Lens.OrthographicSize;
        }
    }
    bool interpolating = false;
    float startTime;
    float interpolationDirection;
    float startSize;
    private void Update()
    {
        if(interpolating)
        {
            LensSettings lens = cam.m_Lens;
            float timeCalc = (Time.timeSinceLevelLoad - startTime) / (interpolationTime);
            timeCalc = Mathf.Clamp(timeCalc, 0, 1);
            float currentSize = startSize+/*Mathf.Lerp(startSize, cameraSize, timeCalc)*/timeCalc*interpolationDirection;
            lens.OrthographicSize = currentSize;
            cam.m_Lens = lens;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform != null && collision.transform.CompareTag("Player"))
            interpolating = false;
        Debug.Log(transform.name);
                //{
        //    CinemachineVirtualCamera cam = collision.transform.GetComponent<CinemachineVirtualCamera>();
        //}
    }
}
