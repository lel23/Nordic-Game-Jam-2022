using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public Rigidbody2D rb2D;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if ()
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1);

    }
    private void OnCollisionStay(Collision collision)
    {
        // If blocking
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Bounce object off
            if (collision.gameObject.CompareTag("Arrow"))
            {
                //collision.gameObject.GetComponent<>;

                // Flip arrow and move down, then destroy
            }

        }

        // If parrying
        if (Input.GetKeyDown(KeyCode.DownArrow) && (Input.GetKeyDown(KeyCode.P)))
        {
            // Bounce object off with force

            // Flip arrown, move up until it lands, then destroy

        }
    }
}
