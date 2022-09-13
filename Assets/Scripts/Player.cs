using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string level;

    public float speed = 5;
    public float jumpForce;

    private bool grounded = true;
    private bool crouched = false;

    public LayerMask ground;
    public Transform groundCheckPoint;
    public float groundCheckRadius;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    public Sprite side;
    public Sprite crouch;
    public Sprite jump;

    private AudioSource source;

    public AudioClip jumpSound;
    public AudioClip flagGetSound;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, ground);

        if (Input.GetKey(KeyCode.LeftArrow) && !crouched)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            sr.sprite = side;
            sr.flipX = true;
        } else if (Input.GetKey(KeyCode.RightArrow) && !crouched)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            sr.sprite = side;
            sr.flipX = false;
        } else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.UpArrow) && grounded && !crouched)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            source.clip = jumpSound;
            source.Play();

        } else if (Input.GetKeyDown(KeyCode.DownArrow) && !crouched)
        {
            speed /= 2;
            sr.sprite = crouch;
            sr.flipX = false;
            crouched = true;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && crouched)
        {
            speed *= 2;
            sr.sprite = side;
            sr.flipX = false;
            crouched = false;
        }

        // restart the level
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("Flag"))
        {
            source.clip = flagGetSound;
            source.Play();
            SceneManager.LoadScene(level);
        }
    }
}
