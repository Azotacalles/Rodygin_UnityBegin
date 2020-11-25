﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float radiusDamage;
    [SerializeField] private float forceExplosion;

    private Rigidbody rb;
    private BoxCollider colliderBox;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        colliderBox = GetComponent <BoxCollider>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        colliderBox.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Collider[] damageCollider = Physics.OverlapSphere(transform.position, radiusDamage);//, enemyLayer);
            foreach (var item in damageCollider)
            {
                if (item.gameObject.layer == 8) //8 - Enemy
                    item.gameObject.GetComponent<DamageEnemyScript>().Health = 0;
                if (item.gameObject.layer == 9) //9 - Explosion
                {
                    var heading = item.transform.position - transform.position;
                    var distance = heading.magnitude;
                    var direction = heading / distance;
                    item.gameObject.GetComponent<Rigidbody>().AddForce(direction * forceExplosion);
                }
            }
        }
    }
}
