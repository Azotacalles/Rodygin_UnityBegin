using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speedBullet;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.velocity = transform.forward * speedBullet;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<DamageEnemyScript>().Health -= 25;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MyGameEnding>().PlayerHealth -= 10;
        }
        if (other.gameObject.CompareTag("Turel"))
        {
            other.gameObject.GetComponent<TurelScript>().Health -= 10;
        }
        Destroy(gameObject);
    }
}
