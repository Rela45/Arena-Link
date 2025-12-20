using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public Weapon weapon;

    Vector2 moveDirection;
    Vector2 mousePosition;

    public float dashSpeed = 20f;
    public float dashDuration = 1f;
    public float dashCooldown = 1f;

    bool isDashing = false;
    float lastDashTime = -999f;
    Vector2 dashDirection;
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= lastDashTime + dashCooldown)
        {
            Debug.Log("sto premendo Q");
            if (moveDirection.sqrMagnitude > 0.01f)
            {
                dashDirection = moveDirection;
            }
            else
            {
                Vector2 aimDir = mousePosition - rb.position;
                if (aimDir.sqrMagnitude > 0.01f)
                {
                    dashDirection = aimDir.normalized;
                }
                else
                {
                    dashDirection = transform.up;
                }
            }
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            rb.linearVelocity = dashDirection * dashSpeed;
        }
        else
        {
            rb.linearVelocity = moveDirection * moveSpeed; 
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = MathF.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }
    }

    IEnumerator Dash()
    {
        Debug.Log("sto effettuando il dash");
        isDashing = true;
        lastDashTime = Time.time;
        float t = 0f;
        while (t < dashDuration)
        {
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        isDashing = false;
    }
}
