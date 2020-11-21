using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject mine;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private Transform spawnMine;
    [SerializeField] private GameObject player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnBullet.position, player.transform.rotation);
        }
        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(mine, spawnMine.position, player.transform.rotation);
        }
    }
}
