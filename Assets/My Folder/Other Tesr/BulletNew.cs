using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNew : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().useGravity = true;
        Debug.Log(collision.gameObject.name);

        var enemy = collision.gameObject.GetComponent<NewEnemy>();
        if (enemy) enemy.OnHit();
    }

}
