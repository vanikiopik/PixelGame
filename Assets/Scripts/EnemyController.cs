using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    private GameObject _target;  //Get player pos
    private SpriteRenderer _sr;

    [SerializeField]
    private int _health = 100;


    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _target = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        float speed = 1f;
        Vector3 dir = _target.transform.position - transform.position;
        bool isLeft = dir.x < 0f;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        _sr.flipY = isLeft;


        //Checking for close distance to object
        if(Vector3.Distance(_target.transform.position, transform.position) <= 0.8f)
        {
            speed = 0f;
        }

        //Moving to the object
        transform.position += (_target.transform.position - transform.position).normalized * Time.deltaTime * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherRigidbody)
        {
            takeDamage(20);
            Debug.Log("Hit");
        }
    }


    private void OnDrawGizmos()
    { 
    }

    public void takeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
