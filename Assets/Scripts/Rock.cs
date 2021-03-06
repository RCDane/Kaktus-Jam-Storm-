﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rock : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D RigBod;
    BoxCollider2D boxCollider;
    [SerializeField] LayerMask rockLayer;
    void Start () {
        RigBod = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        DistanceJoint2D joint = GetComponent<DistanceJoint2D>();

        if(Input.GetKey("joystick button 0")|| Input.GetKey("w")) {
            Destroy(joint);
        } else if((Input.GetKey("joystick button 1") || Input.GetKey("p")) ^ joint != null) {
            if(joint != null) {
                Destroy(joint);
            } else {
                var o = GameObject.FindGameObjectWithTag("Player");
                if((o.transform.position - transform.position).magnitude <= 1.5f) {
                    joint = gameObject.AddComponent<DistanceJoint2D>();
                    joint.autoConfigureDistance = false;
                    joint.distance = 1.2f;
                    joint.connectedBody = o.gameObject.GetComponent<Rigidbody2D>();
                }
            }

        }

    }
    
}
