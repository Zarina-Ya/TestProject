using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMine : MonoBehaviour
{
    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform _mineSpawnPlace;
    private bool _isSpawning;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) _isSpawning = true;
    }

    void FixedUpdate()
    {
        if (_isSpawning)
        {
            _isSpawning = false;
            Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
        }
    }
}
