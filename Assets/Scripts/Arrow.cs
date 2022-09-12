using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "ShellCollider")
        {
            
        } else if (other.collider.name == "VulnerableCollider")
        {
            RestartTheGame(other);

        }
    }

    void RestartTheGame(Collision2D other)
    {
        Destroy(other.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
