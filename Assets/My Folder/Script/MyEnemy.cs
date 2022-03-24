using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Player _player;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnPositionBullet;

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

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 3)
        {
            if (Input.GetButtonDown("Fire2")) Fire();
        }
    }

    private void Die()
    {
        Destroy(gameObject);    
    }


    private void Fire()
    {
        var bulletObj = Instantiate(_bulletPrefab, _spawnPositionBullet.position, _spawnPositionBullet.rotation);
        var bullet = bulletObj.GetComponent<Bullet>();
        bullet.Init(_player.transform,5f,3f);
    }
}
