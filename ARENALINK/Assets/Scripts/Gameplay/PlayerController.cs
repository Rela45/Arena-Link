using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;

    Vector2 moveDirection;
    Vector2 mousePosition;

    public float dashSpeed = 20f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 1f;

    bool isDashing = false;
    float lastDashTime = -999f;
    Vector2 dashDirection;
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.Q) && Time.time >= lastDashTime + dashCooldown)
        {
            if(moveDirection.sqrMagnitude > 0.01f)
            {
                dashDirection = moveDirection;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = MathF.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    IEnumerator Dash()
    {
        isDashing = true;
        lastDashTime = Time.time;
        float t = 0f;
        while(t < dashDuration)
        {
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        isDashing = false;
    }
}
