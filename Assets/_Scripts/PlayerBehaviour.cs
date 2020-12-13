using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int maxLives = 3;
    public int currentLives;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public AudioClip deathSFX;
    public AudioClip flagSFX;
    public AudioClip gemSFX;
    public AudioClip jumpSFX;

    private Transform currentMovingPlatform;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            _Jump();
        }
    }

    private void _Move()
    {
        if (joystick.Horizontal > joystickHorizontalSensitivity)
        {
            if (isGrounded)
                rb.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            else
                rb.AddForce(Vector2.right * horizontalForce / 2 * Time.deltaTime);
            spriteRenderer.flipX = false;
            m_animator.SetInteger("AnimState", 1);
        }

        else if (joystick.Horizontal < -joystickHorizontalSensitivity)
        {
            if (isGrounded)
                rb.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            else
                rb.AddForce(Vector2.left * horizontalForce / 2 * Time.deltaTime);
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
        if (!isJumping)
        {
            GetComponent<AudioSource>().clip = jumpSFX;
            GetComponent<AudioSource>().Play();
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
            isJumping = false;
        }
        else if (other.gameObject.tag == "MovingPlatform")
        {
            isGrounded = true;
            isJumping = false;
            currentMovingPlatform = other.gameObject.transform;
            transform.SetParent(currentMovingPlatform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
            currentMovingPlatform = null;
        }
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            LoseLife();
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            LoseLife();
        }

        if (other.gameObject.tag == "Platform")
        {
            isGrounded = true;
            isJumping = false;
        }

        if (other.gameObject.tag == "Pickup")
        {
            //Apply Pickup benefits
            GetComponent<AudioSource>().clip = gemSFX;
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }

    public void LoseLife()
    {
        GetComponent<AudioSource>().clip = deathSFX;
        GetComponent<AudioSource>().Play();

        transform.position = spawnPoint.position;
        currentLives--;

        switch (currentLives)
        {
            case 2:
                life3.SetActive(false);
                break;
            case 1:
                life2.SetActive(false);
                break;
            case 0:
                life1.SetActive(false);
                break;
            case -1:
                spawnPoint = GameObject.FindWithTag("StartingPosition").transform;
                currentLives = maxLives;
                SceneManager.LoadScene("Defeat Screen");
                //Reset score
                break;
            default:
                print("Amount of lives remaining error!");
                break;
        }
    }
}
