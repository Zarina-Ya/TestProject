using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{

    [SerializeField] private float m_Speed = 5f;

    [SerializeField] private Transform _target;

    [SerializeField] private float _minDistance;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(_target.position, transform.position) > _minDistance && Vector3.Distance(_target.position, transform.position) < 5)
        transform.position = Vector3.MoveTowards(transform.position, _target.position , m_Speed* Time.deltaTime);
        transform.LookAt(_target.position);
    }
}
