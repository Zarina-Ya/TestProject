using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 100f;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private bool _isGrounded;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();   
        
    }


    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
      

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement.Normalize();
        //_rb.AddForce(movement * _speed);
        _rb.velocity = movement * _speed;
       
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * _jumpForce);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGroundUpdate(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGroundUpdate(collision, false);
    }

    private void IsGroundUpdate(Collision collision, bool isGr)
    {
        if(collision.gameObject.tag == "Ground") _isGrounded = isGr;
    }
}
