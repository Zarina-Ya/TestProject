using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Player _player;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnPositionBullet;

    [SerializeField] private float _coolDown;
    [SerializeField] private bool _isFire;


    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _isFire = true; 
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
        //Ray ray = new Ray(_spawnPositionBullet.position, transform.forward);
        //Debug.DrawRay(_spawnPositionBullet.position, transform.forward * 6 , Color.red );
        //if (Physics.Raycast(ray, out RaycastHit hit, 6))
        //{
        //    if (hit.collider.CompareTag("Player"))
        //    {
        //        if (_isFire) Fire();
        //    }
        //}
        if (Vector3.Distance(transform.position, _player.transform.position) < 6)
        {
            if (_isFire) Fire();
        }
    }

    public void Die()
    {
        
        Rigidbody rb = GetComponent<Rigidbody>();
     
        rb.AddForce(-Vector3.forward * 500f);
        rb.AddTorque(Vector3.right * 500f);
    
         Destroy(gameObject, 3f);    
    }


    private void Fire()
    {
        _isFire = false;
        var bulletObj = Instantiate(_bulletPrefab, _spawnPositionBullet.position, _spawnPositionBullet.rotation);
        var bullet = bulletObj.GetComponent<Bullet>();
        bullet.Init(_player.transform,5f,3f);

        Invoke(nameof(Reloading), _coolDown);
    }

    private void Reloading()
    {
        _isFire = true;
    }
}
