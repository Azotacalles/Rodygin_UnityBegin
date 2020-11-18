using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject mine;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnPoint.position, player.transform.rotation);
        }
        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(mine, spawnPoint.position, player.transform.rotation);
        }
    }
}
