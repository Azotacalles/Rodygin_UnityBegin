using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurelScript : MonoBehaviour
{
    [SerializeField] private Transform player;    
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnBullet;
    [SerializeField] private GameObject head;
    private float rateOfFire = 2f;
    private int health = 100;

    public int Health
    {
        set { health = value; }
        get { return health; }
    }

    void Update()
    {
        print("Turel");
        if (health > 0)
        {
            if (Vector3.Distance(transform.position, player.position) < 10)
            {
                transform.LookAt(player);
                Fire();
            }
        }
        else
        {
            head.transform.Rotate(new Vector3(30, 0 ,0));
            enabled = false;
        }
    }

    private void Fire()
    {
        if (rateOfFire > 0) rateOfFire -= Time.deltaTime;
        else
        {
            Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
            rateOfFire = 2f;
        }
    }
}
