﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    private Color playerColor;

    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private float moveSpeed = 7f;
    [SerializeField]
    private float jumpForce = 14f;
    [SerializeField]
    private AudioSource jumpSoundEffect;

    private enum MovementState { idle,running,jumping,falling}

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;

        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()   
    {
        dirX = Input.GetAxis("Horizontal");
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        if (transform.rotation.z != 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) &&  IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
      
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,0f, Vector2.down, .1f,jumpableGround);
    }

    public void OnCherryCollected(Color newColor)
    {
        playerColor = newColor;
        sprite.color = playerColor;
    }
}
