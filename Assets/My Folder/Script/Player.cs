using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _turningSpeed;
    [SerializeField] private Vector3 _direction;// ???????????

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float _jumpPower = 50f;
    [SerializeField] private bool _isGrounded;

    [SerializeField] private int _health;


    [SerializeField] private Animator _animator;
    float rotation, move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }



    public void Update()
    {
       // while (true) Debug.Log("AAAAAAAAAAAAAAAAAAAAA"); ????????? ?????? ? ?????? ???? ? ????????? ????????, ??? ??? ? Update - ???? ?????? , ?????????????? ?????? ???? , ????????? while - ?? ?? ?????? ?? ?????? , ????????????? ? ????????? ????? ?? ????? ??????????????  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void Jump()
    {
        if (_isGrounded)
        {
            rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _animator.SetBool("IsJumping",true);
        }
        else
        {
            _animator.SetBool("IsJumping", false);
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
        if (collision.gameObject.GetComponent<Ground>()) _isGrounded = isGr;
       
    }

    public void FixedUpdate()
    {
        rotation = Input.GetAxis("Horizontal") * 3;
        move = Input.GetAxis("Vertical") * _turningSpeed * Time.deltaTime;

        _animator.SetBool("IsWalking", move > 0);

        transform.rotation *= Quaternion.Euler(0f, rotation, 0f);
        rb.MovePosition(transform.position + transform.forward * move);


    }
    public void HurtPlayer(int damage)
    {
        Debug.Log("Player::: Ouch: " + damage + "\n_health" + _health);
        _health -= damage;
        if (_health <= 0)
        {
          // rb.isKinematic = true;
           Destroy(gameObject);
        }

    }

}
