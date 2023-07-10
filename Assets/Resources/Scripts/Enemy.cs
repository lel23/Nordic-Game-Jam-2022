using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    public Sprite side;
    public Sprite hit;

    public float slimeSpeed = 5f;
    public float maxDist = 20f;
    public float timer = 0;

    public GameObject arrowPrefab;
    private float rateOfFire = 0.5f;
    private float lastTimeFired = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((lastTimeFired + 1 / rateOfFire) < Time.time)
        {
            lastTimeFired = Time.time;
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 newPos = new Vector3(transform.position.x - 0.7f, transform.position.y, 0);
        GameObject child = Instantiate(arrowPrefab, newPos, Quaternion.identity);
    }
}
