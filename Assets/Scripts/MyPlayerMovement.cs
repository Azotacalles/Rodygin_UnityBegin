using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float turnSpeed;

    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        JumpLogic();

        MovementLogic();

        RotateLogic();
    }

    private void RotateLogic()
    {
        Vector3 rotation = Vector3.zero;
        rotation.y = Input.GetAxis("Horizontal");
        transform.Rotate(rotation * turnSpeed * Time.fixedDeltaTime);
    }

    private void MovementLogic()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpSpeed);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = value;
        }
    }
}
