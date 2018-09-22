using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float moveSpeed,maxSpeed,maxAirSpeed;
    [SerializeField] LayerMask groundLayer;


    BoxCollider2D boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        playerRB = GetComponent<Rigidbody2D>();
    }
    Rigidbody2D playerRB;
    private float XInput;
    private void FixedUpdate()
    {
        RaycastHit2D hit;
        float size = boxCollider.size.x;
        hit = Physics2D.BoxCast(transform.position, boxCollider.size * 0.98f * transform.localScale.x, 0, Vector2.down, 0.1f, groundLayer, Mathf.Infinity);

        playerRB.AddForce(XInput * moveSpeed * Time.deltaTime * Vector2.right, ForceMode2D.Impulse);
        Vector2 velocity = playerRB.velocity;

        if (hit.transform != null)
        {
            if (Mathf.Abs(velocity.x) > maxSpeed)
                velocity.x = maxSpeed * Mathf.Sign(velocity.x);
        }
        else
        {
            if (Mathf.Abs(velocity.x) > maxAirSpeed)
                velocity.x = maxAirSpeed * Mathf.Sign(velocity.x);
        }

        
        
        playerRB.velocity = velocity;
        //Debug.Log("Velocity: " + velocity.x);
    }

    public void Move(float x)
    {
        XInput = x;
    }

}
