using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int _health { get; set; }
    public HealthBar _hpBar;


    private void Start()
    {
        _health = 100;
    }


    private void Update()
    {
           
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collides with: " + collision.gameObject.name);
        if (collision.gameObject.name == "BoxTest")
            takeDamage(20);
    }


    public void takeDamage(int damage)
    {
        _health -= damage;
        _hpBar.HpDecrease();
        if (_health <= 0)
        {
            Debug.Log("Player is dead");
            Destroy(gameObject);
        }
    }
}
