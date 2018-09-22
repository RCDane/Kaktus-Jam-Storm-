using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    [SerializeField] float jumpPower;
    [SerializeField] LayerMask groundLayer;
    Rigidbody2D playerRB;
    [SerializeField] float minGravity, maxGravity;

    BoxCollider2D boxCollider;
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        jumpTimer = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        JumpSystem();
    }
    bool JumpReleased;
    void JumpSystem()
    {
        RaycastHit2D hit;
        float size = boxCollider.size.x;
        hit = Physics2D.BoxCast(transform.position, boxCollider.size * 0.98f, 0, Vector2.down, 1f, groundLayer, Mathf.Infinity);
        
        if (hit.transform != null && hit.transform.CompareTag("Ground") && jumpTimer + 0.3f < Time.timeSinceLevelLoad)
        {
            playerRB.gravityScale = minGravity;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetButton("Fire1") || Input.GetKey(KeyCode.UpArrow))
            return;
       
        if (hit.transform == null)
        {
            playerRB.gravityScale = maxGravity;
            JumpReleased = true;
        }
    }
    float jumpTimer;
    // Use this for initialization
    public void TryJump()
    {
        RaycastHit2D hit;
        float size = boxCollider.size.x;
        hit = Physics2D.BoxCast(transform.position, boxCollider.size * 0.98f *transform.localScale.x, 0, Vector2.down, 0.1f,groundLayer,Mathf.Infinity);
        if (hit.transform != null && hit.transform.CompareTag("Ground") && jumpTimer + 0.3f< Time.timeSinceLevelLoad)
        {
            playerRB.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpTimer = Time.timeSinceLevelLoad;
            playerRB.gravityScale = minGravity;
            JumpReleased = false;
        }
    }
}
