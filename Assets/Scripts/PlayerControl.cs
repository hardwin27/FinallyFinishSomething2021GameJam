using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool isControlled;

    public float speed;
    protected float moveDirection;

    public float jumpVelocity;
    public float cayoteJumpDuration;
    protected bool jumpPressed = false;
    protected float jumpTimer = 0.0f;

    public GameObject groundTriggerObject;
    protected GroundTrigger groundTrigger;
    
    protected Rigidbody2D body;

    protected SpriteRenderer sprite;

    public GameObject charaChangerTriggerObject;
    CharaChangerTrigger charaChangerTrigger;

    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundTrigger = groundTriggerObject.GetComponent<GroundTrigger>();
        sprite = GetComponent<SpriteRenderer>();
        enabled = isControlled;
        if (enabled)
        {
            sprite.sortingOrder = 5;
        }
        charaChangerTrigger = charaChangerTriggerObject.GetComponent<CharaChangerTrigger>();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.K))
        {
            if (charaChangerTrigger.otherCharacter != null)
            {
                ChangeThisCharacter(charaChangerTrigger.otherCharacter);
            }
        }

        moveDirection = Input.GetAxis("Horizontal");

        if (moveDirection > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    protected virtual void FixedUpdate() 
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

    public void ChangeThisCharacter(PlayerControl otherCharacter)
    {
        sprite.sortingOrder = 1;
        otherCharacter.enabled = true;
        body.velocity = Vector2.zero;
        otherCharacter.sprite.sortingOrder = 5;
        enabled = false;
    }

    // public void SwitchToThis()
    // {
    //     if (!this.enabled)
    //     {
    //         this.enabled = true;
    //         this.sprite.sortingOrder = 5;
    //     }
    // }
}
