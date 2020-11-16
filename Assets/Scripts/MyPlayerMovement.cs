using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    [SerializeField] private float jump;
    [SerializeField] private float speed;
    private Vector3 direction;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jump, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        var newSpeed = direction * speed * Time.fixedDeltaTime;
        transform.Translate(newSpeed);
    }
}
