using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CoinCounter CC;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Sprite[] spriteArray;
    [SerializeField] bool isJetpack;
    [SerializeField] private float jumpForce = 100.0f;  
    [SerializeField] private float speed = 100.0f;

    void Start()
    {
       isJetpack = false;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        CC = GetComponentInChildren<CoinCounter>();
    }


    void Update()
    {
        if (isJetpack)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                sr.sprite = spriteArray[0];
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                sr.sprite = spriteArray[2];
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                sr.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                sr.sprite = spriteArray[2];
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                sr.flipX = true;
            }
        }

        if (!isJetpack)
        {
            if (Input.GetKey(KeyCode.D))
            {
                sr.sprite = spriteArray[1];
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                sr.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                sr.sprite = spriteArray[1];
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                sr.flipX = true;
            }

            //Jump without JP
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, 3f);
                sr.flipX = false;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Jetpack")
        {
            isJetpack = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            CC.CoinPickUp();
        }
    }
}

