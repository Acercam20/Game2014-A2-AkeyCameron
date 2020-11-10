using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float joystickHorizontalSensitivity;
    public float joystickVerticalSensitivity;
    public float horizontalForce;
    public float verticalForce;
    public float jumpForce;
    public float maximumVelocity;
    public bool isGrounded;
    public bool isJumping;
    public Transform spawnPoint;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        _Move();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _Jump();
        }
    }

    private void _Move()
    {
        if (joystick.Horizontal > joystickHorizontalSensitivity)
        {
            rb.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            spriteRenderer.flipX = false;
            m_animator.SetInteger("AnimState", 1);
        }

        else if (joystick.Horizontal < -joystickHorizontalSensitivity)
        {
            rb.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            spriteRenderer.flipX = true;
            m_animator.SetInteger("AnimState", 1);
        }
        else
        {
            m_animator.SetInteger("AnimState", 0);
        }
    }

    public void _Jump()
    {
        if (isGrounded)
        {
            m_animator.SetInteger("AnimState", 2);
            rb.AddForce(Vector2.up * verticalForce);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathPlane"))
        transform.position = spawnPoint.position;
    }
}
