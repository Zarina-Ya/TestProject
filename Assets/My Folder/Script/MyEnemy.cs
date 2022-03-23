using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    public void Hurt(int damage)
    {
        Debug.Log("Ouch: " + damage);
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }

    }
   
    private void Die()
    {
        Destroy(gameObject);    
    }
}
