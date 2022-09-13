using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    public GameObject arrow;

    public Sprite side;
    public Sprite hit;

    public float slimeSpeed = 5f;
    public float maxDist = 20f;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(slimeSpeed, 0);
        Vector2 vel = rb2d.velocity;

        if (this.gameObject.CompareTag("Slime"))
        {
            for (int i = 0; i < 30; i++)
            {
                
                vel.x *= -1;
                Debug.Log("Velocity: " + rb2d.velocity);
                i = 0;
            }
        }
        /*
        if (this.gameObject.CompareTag("Bee"))
        {

        }

        if (this.gameObject.CompareTag("Cricket"))
        {

        }
        */


    }

    void Shoot()
    {
    }
}
