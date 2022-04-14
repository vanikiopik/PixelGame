using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenPyus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy object when it'll touch other RigBody border
        if (collision.otherRigidbody)
        {
            Destroy(gameObject);
        }
    }
}
