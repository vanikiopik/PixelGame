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

    void Update() 
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
