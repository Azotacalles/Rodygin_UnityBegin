using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    [SerializeField] private float jump;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private Vector3 direction;
    private Rigidbody rb;

    private Vector3 rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //direction.x = Input.GetAxis("Horizontal");
        rotation.y = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        if(Input.GetButtonDown("Vertical") && direction.z < 0)
        {
            transform.rotation *= Quaternion.AngleAxis(180, transform.up);
            print("---");
        }
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jump, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        var newSpeed = direction * speed * Time.fixedDeltaTime;
        transform.Translate(newSpeed);

        transform.Rotate(rotation * turnSpeed * Time.fixedDeltaTime);
    }
}
