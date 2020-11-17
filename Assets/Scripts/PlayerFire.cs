using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private GameObject player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnBullet.position, player.transform.rotation);
        }
            
    }
}
