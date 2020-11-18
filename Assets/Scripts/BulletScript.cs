using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speedBullet;
    private Rigidbody rb;
    private MyGameEnding gameEnding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameEnding = GameObject.Find("JohnLemon").GetComponent<MyGameEnding>();
    }

    
    void Update()
    {
        rb.velocity = transform.forward * speedBullet;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
