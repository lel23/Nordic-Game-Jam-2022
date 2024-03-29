using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2d;

    public float lifeTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "ShellCollider")
        {
            // If the arrow hits the ground, destroy it
            BounceOff();

        } 
        else if (other.collider.name == "VulnerableCollider")
        {
            other.gameObject.GetComponent<LPlayer>().Die();
        }
        else if (other.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
    public void BounceOff()
    {
        Destroy(gameObject);
    }
}
