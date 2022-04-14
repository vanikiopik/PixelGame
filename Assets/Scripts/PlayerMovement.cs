using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
    }


    void Update()
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
        if (Input.GetKey(KeyCode.Space) && !isJetpack)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5f);
            sr.flipX = false;
        }




        if (isJetpack)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                sr.sprite = spriteArray[0];
              rb.AddForce(new Vector3(0, jumpForce, 0));
            }
        }

    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Jetpack")
        {
            isJetpack = true;
            Debug.Log(isJetpack);
        }
    }
}

