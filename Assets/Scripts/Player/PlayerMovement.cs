using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float moveSpeed;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    Rigidbody2D playerRB;
    private float XInput;
    private void FixedUpdate()
    {
        playerRB.AddForce(XInput * moveSpeed * Time.deltaTime*Vector2.right,ForceMode2D.Impulse);
    }

    public void Move(float x)
    {
        XInput = x;
    }

}
