using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;  //Get player pos


    void Start()
    {
        
    }

    void Update()
    {
        transform.position += (target.transform.position - gameObject.transform.position).normalized * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherRigidbody)
        {
            Debug.Log("Hit");
        }
    }
}
