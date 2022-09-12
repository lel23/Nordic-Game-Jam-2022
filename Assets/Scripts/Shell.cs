using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public Collider2D col2D;


    // Start is called before the first frame update
    void Start()
    {
        col2D = GetComponent<Collider2D>();
    }

    
    private void OnCollisionEnter(Collision other)
    {
        // If blocking
        

        // If parrying
        if (Input.GetKeyDown(KeyCode.DownArrow) && (Input.GetKeyDown(KeyCode.P)))
        {
            // Bounce object off with force

            // Flip arrown, move up until it lands, then destroy

        }
    }
}
