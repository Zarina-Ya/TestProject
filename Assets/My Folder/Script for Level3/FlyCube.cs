using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCube : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _speed = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * _rotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * _speed;

        rb.AddRelativeForce(0f,0f,forwardForce);
        rb.AddRelativeTorque(0f, sideForce, 0f);

        //rb.AddForce(sideForce,0,forwardForce);  
    }
}
