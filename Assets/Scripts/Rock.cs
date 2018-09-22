using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rock : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D RigBod;

    void Start () {
        RigBod = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(RigBod.bodyType == RigidbodyType2D.Dynamic) {
            if(Input.GetKey("e")) {
                var o = GameObject.FindGameObjectWithTag("Player");
                //transform.position = Vector2.MoveTowards(transform.position,o.transform.position,0.5f);
                RigBod.AddForce(o.transform.position - transform.position,ForceMode2D.Impulse);
                
            }
            
        }
            
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Player")) {
            Debug.Log("With Player!");
            var RB = GetComponent<Rigidbody2D>();
            RB.bodyType = RigidbodyType2D.Dynamic;
            RigBod.velocity = Vector2.zero;
        }
    }
    void OnCollisionStay(Collision col) {
        if(col.gameObject.CompareTag("Player")) {
            Debug.Log("Still here!");
            RigBod.velocity = Vector2.zero;
        }
    }
}
