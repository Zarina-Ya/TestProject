using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPhisic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool _isGround;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _isGround = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void Jump()
    {
        if(_isGround) rb.AddForce(0f, 400f, 0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _isGround = false;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) rb.AddForce(-15f, 0f, 0f);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(15f, 0f, 0f);

    }
}
