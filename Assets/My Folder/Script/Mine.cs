using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<MyEnemy>();

            var rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = false;

            enemy.Hurt(_damage);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
}
