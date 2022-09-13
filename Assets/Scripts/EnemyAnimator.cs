using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    public Sprite[] sideEnemy;

    public int spriteIndex = 0;

    Rigidbody2D rb2D;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rb2D.velocity;

        sr.sprite = sideEnemy[spriteIndex];
        spriteIndex++;
        if (spriteIndex >= sideEnemy.Length)
        {
            spriteIndex = 0;
        }

        if (vel.x > 0)
        {
            sr.flipX = false;
        }
        if (vel.x < 0)
        {
            sr.flipX = true;
        }
        
    }
}