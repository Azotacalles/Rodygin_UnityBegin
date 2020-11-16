using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject pointSpawnEnemy;

    void Start()
    {
        GameObject[] pointsSpawnEnemy = GameObject.FindGameObjectsWithTag("PointSpawnEnemy");
        foreach (var item in pointsSpawnEnemy)
        {
            Instantiate(pointSpawnEnemy, item.transform.position, item.transform.rotation);
        }
    }
}
