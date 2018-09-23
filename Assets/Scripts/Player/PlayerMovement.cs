using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PlayerMovement : MonoBehaviour {

    [SerializeField]

    private float moveSpeed, maxSpeed;



    private void Start() {

        playerRB = GetComponent<Rigidbody2D>();

    }

    Rigidbody2D playerRB;

    private float XInput;

    private void FixedUpdate() {

        playerRB.AddForce(XInput * moveSpeed * Time.deltaTime * Vector2.right,ForceMode2D.Impulse);

        Vector2 velocity = playerRB.velocity;

        if(Mathf.Abs(velocity.x) > maxSpeed)

            velocity.x = maxSpeed * Mathf.Sign(velocity.x);

        if(Mathf.Sign(velocity.x) > 0) {
            var rend = GetComponent<SpriteRenderer>();
            rend.flipX = false;
        } else {
            var rend = GetComponent<SpriteRenderer>();
            rend.flipX = true;
        }

        playerRB.velocity = velocity;

        //Debug.Log("Velocity: " + velocity.x);

    }



    public void Move(float x) {

        XInput = x;

    }



}