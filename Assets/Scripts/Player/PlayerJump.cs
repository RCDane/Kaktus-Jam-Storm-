using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    [SerializeField] float jumpPower;

    Rigidbody2D playerRB;


    BoxCollider2D boxCollider;
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    public void TryJump()
    {
        RaycastHit2D hit;
        //hit = Physics2D.BoxCast()
        //if()
        playerRB.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}
