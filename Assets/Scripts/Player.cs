using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce;

    private bool grounded = true;
    private bool crouched = false;

    public LayerMask ground;
    public Transform groundCheckPoint;
    public float groundCheckRadius;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, ground);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        } else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.UpArrow) && grounded && !crouched)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && !crouched)
        {
            speed /= 2;
            crouched = true;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && crouched)
        {
            speed *= 2;
            crouched = false;
        }



    }

}
