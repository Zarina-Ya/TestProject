using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    [SerializeField] private float _delay = 3f;
    private float _countDown;

    [SerializeField] ParticleSystem _effect;
   
   [SerializeField] bool _hasExploded;

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



      

        Destroy(gameObject);

        


    }
}
