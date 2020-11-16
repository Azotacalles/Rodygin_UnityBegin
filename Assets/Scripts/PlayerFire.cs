using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Instantiate(bullet, spawnBullet.position, Quaternion.identity);
    }
}
