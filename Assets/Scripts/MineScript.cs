using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float radiusDamage;
    [SerializeField] private LayerMask enemyLayer;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        if(collision.collider.gameObject.CompareTag("Enemy"))
        {
            Collider[] damageCollider = Physics.OverlapSphere(transform.position, radiusDamage, enemyLayer);
            foreach (var item in damageCollider)
            {
                item.gameObject.GetComponent<DamageEnemyScript>().Health = 0;
            }
        }
    }
}
