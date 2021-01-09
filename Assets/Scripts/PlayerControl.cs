using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    float moveDirection;

    public float jumpVelocity;
    public float cayoteJumpDuration;
    bool jumpPressed = false;
    float jumpTimer = 0.0f;

    public GameObject groundTriggerObject;
    GroundTrigger groundTrigger;
    
    Rigidbody2D body;

    SpriteRenderer sprite;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundTrigger = groundTriggerObject.GetComponent<GroundTrigger>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        moveDirection = Input.GetAxis("Horizontal");

        if (moveDirection > 0)
        {
            sprite.flipX = false;
        }
        else if (moveDirection < 0)
        {
            sprite.flipX = true;
        }
    }

    void FixedUpdate() 
    {
        if (groundTrigger.isGrounded)
        {
            jumpTimer = cayoteJumpDuration;
        }
        else
        {
            if (jumpTimer >= 0)
            {
                jumpTimer -= Time.fixedDeltaTime;
            }
        }
        if (jumpPressed)
        {
            if (jumpTimer > 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpVelocity);
            }
        }

        body.velocity = new Vector2(moveDirection * speed, body.velocity.y);
    }
}
