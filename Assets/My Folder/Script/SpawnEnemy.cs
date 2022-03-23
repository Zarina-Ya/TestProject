using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _enemySpawnPlace;
    //[SerializeField] private MyEnemy _player;
    private bool _isSpawning;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Enemy");
            if (player == null) SpawnEnemyPlace();
        }
      

    }

   
    private void SpawnEnemyPlace()
    {
        Instantiate(_enemy, _enemySpawnPlace.position, _enemySpawnPlace.rotation);
    }
}
