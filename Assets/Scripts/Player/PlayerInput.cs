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
        float yInput = Input.GetAxisRaw("Vertical");
        bool jump = Input.GetButtonDown("Fire1");
        playerMovement.Move(xInput);
        if(yInput == 1 || jump)
        {
            playerJump.TryJump();
        }
    }
}
