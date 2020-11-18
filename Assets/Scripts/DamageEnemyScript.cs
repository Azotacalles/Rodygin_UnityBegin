using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyScript : MonoBehaviour
{
    private int health = 100;
    void Start()
    {
        
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health -= 25;
        }
    }
}
