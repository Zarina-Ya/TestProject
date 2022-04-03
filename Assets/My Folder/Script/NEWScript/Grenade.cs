using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    [SerializeField] private float _delay = 3f;
    private float _countDown;

   [SerializeField] ParticleSystem _effect;
   
   [SerializeField] bool _hasExploded;

    [SerializeField] float _radius = 5f;

    private void Start()
    {
        _countDown = _delay;
    }
    void Update()
    {
        _countDown -= Time.deltaTime;
        if( _countDown <= 0f && _hasExploded == false)
        {
            Explode();
            _hasExploded = true;
            
        }
        

    }

    private void Explode()
    {
     
        Debug.Log("BUUM");

        Instantiate(_effect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
    
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if(rb != null )
            {
                rb.AddForce( - Vector3.forward *500f);
                rb.AddTorque(Vector3.right * 500f);
            }

            var enemy = collider.gameObject.GetComponent<MyEnemy>();
            if (enemy) enemy.Die();
        }

      

        Destroy(gameObject);

        


    }
}
