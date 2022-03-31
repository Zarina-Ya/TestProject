using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangAtPosition : MonoBehaviour
{
    [SerializeField] private Rigidbody _targetRb;
    [SerializeField] private float _forceValue;
   // [SerializeField] private ParticleSystem _particSys;

  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _targetRb.AddForceAtPosition(transform.up * _forceValue, transform.position);

           // _particSys.Play();
        }
    }
}
