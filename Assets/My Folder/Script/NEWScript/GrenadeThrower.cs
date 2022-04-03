using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private float _throwForce = 5f;
    [SerializeField] private GameObject _grenadePrefab;
    [SerializeField] private Transform _spawnPosinition;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) ThrowGrenade() ;
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(_grenadePrefab, _spawnPosinition.position, _spawnPosinition.rotation) ;
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * _throwForce, ForceMode.VelocityChange) ;
    }
}
