using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    private MyGameEnding gameEnding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameEnding = GameObject.Find("JohnLemon").GetComponent<MyGameEnding>();
    }

    
    void Update()
    {
        rb.velocity = transform.forward * 20f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            print("Enemy");
            Destroy(other.gameObject);
            gameEnding.Enemies--;
        }
        Destroy(gameObject);
    }
}
