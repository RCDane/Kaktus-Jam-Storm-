using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    PlayerMovement playerMovement;
    PlayerJump playerJump;
	// Use this for initialization
	void Start () {
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
	}
	
	// Update is called once per frame
	void Update () {
        float xInput = Input.GetAxisRaw("Horizontal");
        bool yInput = Input.GetKeyDown(KeyCode.W);
        bool jump = Input.GetButtonDown("Fire1");
        playerMovement.Move(xInput);
        if(yInput || jump)
        {
            playerJump.TryJump();
        }
    }
}
