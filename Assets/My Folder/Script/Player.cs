using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _turningSpeed;
    [SerializeField] private Vector3 _direction;// Направление

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float _jumpPower = 50f;
    [SerializeField] private bool _isGrounded;

    float rotation, move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
    }



    public void Update()
    {
       // while (true) Debug.Log("AAAAAAAAAAAAAAAAAAAAA"); программа уходит в вечный цикл и перестает работать, так как в Update - идет логика , просчитываемая каждый кадр , благодаря while - мы не выйдет из метода , следовательно и следующие кадры не будут просчитываться  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void Jump()
    {
        if (_isGrounded)
            rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
       
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
        if (collision.gameObject.GetComponent<Ground>()) _isGrounded = isGr;
       
    }

    public void FixedUpdate()
    {
        rotation = Input.GetAxis("Horizontal") * 3;
        move = Input.GetAxis("Vertical") * _turningSpeed * Time.deltaTime;

        transform.rotation *= Quaternion.Euler(0f, rotation, 0f);
        rb.MovePosition(transform.position + transform.forward * move);


    }


}
