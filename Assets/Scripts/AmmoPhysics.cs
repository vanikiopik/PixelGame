using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPhysics : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public float destroyTime; //Lifetime of object

    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
    }

    void FixedUpdate() 
    {
        //Better using fixedUpdate to move bullets 
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy object when it'll touch other RigBody border
        if (collision.otherRigidbody)
        {
            DestroyAmmo();
        }
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
