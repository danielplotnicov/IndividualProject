using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    private float dirX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;
    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling,
    };

    private MovementState state = MovementState.idle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1.0f;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1.0f;
        }
        else
        {
            dirX = .0f;
        }
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.gravityScale = 7;
        }
        else
        {
            rb.gravityScale = 1.5f;
        }
        
            AnimationUpdate();
        }

    private void AnimationUpdate()
    {

            MovementState state;

            if (rb.velocity.x > .1f)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (rb.velocity.x < -.1f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }

            if ((rb.velocity.y > .1f) && (!isGrounded()))
            {
                state = MovementState.jumping;
            }
            else if ((rb.velocity.y < -1.1f) && (!isGrounded()))
            {
                state = MovementState.falling;
            }

            anim.SetInteger("state", (int)state);
        
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    
}
