using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    public Transform target;  //Get player pos
    private SpriteRenderer sr;

    [SerializeField]
    private int _health = 100;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float speed = 1f;
        Vector3 dir = target.position - transform.position;
        bool isLeft = dir.x < 0f;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        sr.flipY = isLeft;


        //Checking for close distance to object
        if(Vector3.Distance(target.position, transform.position) <= 0.8f)
        {
            speed = 0f;
        }

        //Moving to the object
        transform.position += (target.transform.position - transform.position).normalized * Time.deltaTime * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherRigidbody)
        {
            takeDamage();
            Debug.Log("Hit");
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(target.position, target.position+ target.right);
        Gizmos.DrawRay(transform.position, target.position);
    }

    public void takeDamage()
    {
        _health = _health -20;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
