using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _turningSpeed;
    [SerializeField] private Vector3 _direction;// Направление

    [SerializeField] private Rigidbody rigidbody;

    [SerializeField] private float _jumpPower = 50f;
    [SerializeField] private bool _isGrounded { get; set; }

    float rotation, move;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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
            rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var ground = collision.gameObject.GetComponentInParent<Ground>();
        if (ground) _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        var ground = collision.gameObject.GetComponentInParent<Ground>();
        if (ground) _isGrounded = false;
    }

    public void FixedUpdate()
    {
        //_direction.Normalize();
        ////// Vector3 dir = new Vector3(_direction.x * _turningSpeed, _direction.y * Time.deltaTime, _direction.z * _turningSpeed);
        //transform.Translate(_direction * _turningSpeed * Time.deltaTime);
        //// transform.Translate(dir);
        ///
        transform.rotation *= Quaternion.Euler(0f, rotation, 0f);
        rigidbody.MovePosition(transform.position + transform.forward * move);

    }


}
