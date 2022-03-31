using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _turningSpeed;
    [SerializeField] private Vector3 _direction;// Направление

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float _jumpPower = 50f;
    [SerializeField] private bool _isGrounded { get; set; }

    float rotation, move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
    }



    public void Update()
    {

        //_direction.x = Input.GetAxis("Horizontal");
        //_direction.z = Input.GetAxis("Vertical");

        rotation = Input.GetAxis("Horizontal") * 3;
        move = Input.GetAxis("Vertical") * _turningSpeed * Time.deltaTime;



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void Jump()
    {
        if(_isGrounded)
            rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var ground = collision.gameObject.GetComponent<Ground>();
        if (ground) _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        var ground = collision.gameObject.GetComponent<Ground>();
        if (ground) _isGrounded = false;
    }

    public void FixedUpdate()
    {
    
        transform.rotation *= Quaternion.Euler(0f, rotation, 0f);
        rb.MovePosition(transform.position + transform.forward * move);


    }


}
