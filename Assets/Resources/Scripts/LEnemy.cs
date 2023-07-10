using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class LEnemy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    public GameObject arrow;
    public float rateOfFire = 0.5f;
    float lastFired = 0;

    public Sprite shooterShoot;

    // BEE references
    public float amplitude = 0.5f;
    public float frequency = 1.2f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public Sprite[] beeFrames;
    public float fps = 10;
    int currentFrame = 0;
    float frameTimer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        posOffset = transform.position;
    }

    void Update()
    {
        if ((lastFired + 1 / rateOfFire) < Time.time)
        {
            lastFired = Time.time;
            Shoot();
        }
        if (gameObject.tag == "Bee")
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;

            frameTimer -= Time.deltaTime;

            if (frameTimer <= 0)
            {
                currentFrame++;
                if (currentFrame == beeFrames.Length - 1)
                {
                    currentFrame = 0;
                }
                frameTimer = (1f / fps);
                sr.sprite = beeFrames[currentFrame];
            }
        }
    }

    void Shoot()
    {
        if (shooterShoot != null) StartCoroutine(ShootAnimator());

        Vector3 newPos = new Vector3(transform.position.x - 0.7f, transform.position.y, 0);
        GameObject child = Instantiate(arrow, newPos, Quaternion.identity);
    }
    IEnumerator ShootAnimator()
    {
        Sprite temp = sr.sprite;
        sr.sprite = shooterShoot;
        yield return new WaitForSeconds(0.2f);
        sr.sprite = temp;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
            other.gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2(0, 5);
            Destroy(gameObject);
        }*/
    }
}
