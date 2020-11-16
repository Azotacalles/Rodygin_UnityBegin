using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody rb;
    private MyGameEnding gameEnding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameEnding = GameObject.Find("JohnLemon").GetComponent<MyGameEnding>();
    }

    
    void Update()
    {
        rb.AddForce(player.transform.forward * 25, ForceMode.Force);
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
