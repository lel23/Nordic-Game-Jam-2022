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

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    void Shoot()
    {
    }
}
