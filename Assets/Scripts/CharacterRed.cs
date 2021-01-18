using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRed : PlayerControl
{
    public float acceleration;
    public float accelerationDecrease;
    float additionalSpeed = 0.0f;
    public float dashCooldown;
    float cooldownTimer = 0.0f;

    protected override void Start() 
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.M))
        {
            if (cooldownTimer <= 0)
            {
                additionalSpeed = acceleration;
                cooldownTimer = dashCooldown;
            }
        }

        if (cooldownTimer >= 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (additionalSpeed > 0.0f)
        {
            body.velocity = new Vector2(body.velocity.x + (sprite.transform.localScale.x * additionalSpeed), body.velocity.y);
            additionalSpeed -= (accelerationDecrease * Time.fixedDeltaTime);
        }
    }
}
