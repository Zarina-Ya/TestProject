using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speedRotate;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnPositionBullet;


    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var direction = _player.transform.position - transform.position;
        var stepRotate = Vector3.RotateTowards(transform.forward, direction, _speedRotate * Time.fixedDeltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(stepRotate);

       //// _tmpRotationBullet.rotation = Quaternion.LookRotation(stepRotate);
       // if (Input.GetButtonDown("MyFire")){// f
       //     Fire(transform);
       // }

        if (Vector3.Distance(transform.position, _player.transform.position) < 3) Fire(transform);  
    }

    private void Fire(Transform trans)
    {
        var bulletObj = Instantiate(_bulletPrefab, _spawnPositionBullet.position, trans.rotation);
        var bullet = bulletObj.GetComponent<Bullet>();
        bullet.Init(_player.transform, 1f, 3f);
    }
}
