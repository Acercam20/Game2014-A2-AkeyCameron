using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float joystickSensitivity;
    public float horizontalForce;
    public float jumpForce;
    public float maximumVelocity;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        if (joystick.Horizontal > joystickSensitivity)
        {
            rb.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            spriteRenderer.flipX = false;
        }
        if (joystick.Horizontal < -joystickSensitivity)
        {
            rb.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            spriteRenderer.flipX = true;

        }
    }
}
