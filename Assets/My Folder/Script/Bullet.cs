using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    private float _speedBullet ;
    // Start is called before the first frame update
    public void Init(Transform transform,float lifeTime, float speed)
    {
        _speedBullet = speed;
        _target = transform;    
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward* _speedBullet * Time.fixedDeltaTime;
    }
}
