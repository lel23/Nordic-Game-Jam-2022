using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class LPlayer : MonoBehaviour
{
    public string level;

    bool grounded = true;
    bool crouch = false;
    public float speed = 5;
    public float jumpForce;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private AudioSource source;

    [Header("Ground")]
    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    float groundCheckRadius = 0.1f;

    [Header("SFX")]
    public AudioClip jumpSound;
    public AudioClip flagSound;
    public AudioClip fail;

    [Header("Animation")]
    public Sprite[] frames;
    public Sprite idle;
    public Sprite crouched;
    public Sprite jumpFall;
    float fps = 10;
    int currentFrame = 0;
    float frameTimer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y < -20) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        // Movement
        /*if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch = !crouch;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

        }*/
        if (Input.GetKey(KeyCode.LeftArrow) && !crouch) 
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        else if (Input.GetKey(KeyCode.RightArrow) && !crouch)
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        else 
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && !crouch)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            source.clip = jumpSound;
            source.Play();
        }

        // Animation
        if (crouch) sr.sprite = crouched;
        else if (rb2d.velocity == Vector2.zero) sr.sprite = idle;
        else if (rb2d.velocity.x != 0)
        {
            if (rb2d.velocity.x < 0) sr.flipX = true;
            else if (rb2d.velocity.x > 0) sr.flipX = false;

            frameTimer -= Time.deltaTime;

            if (frameTimer <= 0)
            {
                currentFrame++;
                if (currentFrame == frames.Length-1)
                {
                    currentFrame = 0;
                }

                frameTimer = (1f / fps);
                sr.sprite = frames[currentFrame];
            }
        }
        if (!grounded && !crouch) sr.sprite = jumpFall;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Flag")
        {
            source.clip = flagSound;
            source.Play();
            StartCoroutine(FlagGet());
        }
    }

    IEnumerator FlagGet()
    {
        rb2d.isKinematic = true;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level);
    }

    public void Die()
    {
        StartCoroutine(DeathProcess());
    }

    IEnumerator DeathProcess()
    {
        source.clip = fail;
        source.Play();
        rb2d.isKinematic = true;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
