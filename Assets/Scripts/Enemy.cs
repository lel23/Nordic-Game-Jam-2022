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
        timer += Time.deltaTime;
        Debug.Log("Timer: " + timer);
        if (this.gameObject.CompareTag("Slime"))
        {
            if (timer > 3)
            {
                rb2d.velocity = new Vector2(slimeSpeed, 0) * -1;
                Debug.Log("Velocity: " + rb2d.velocity);
                timer = 0;
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
