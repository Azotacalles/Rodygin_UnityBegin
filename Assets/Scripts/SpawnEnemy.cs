using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject spawnEnemy;

    void Start()
    {
        GameObject[] pointsSpawnEnemy = GameObject.FindGameObjectsWithTag("PointSpawnEnemy");
        for(int i = 0; i < pointsSpawnEnemy.Length; i++)
        {
            Instantiate(spawnEnemy, pointsSpawnEnemy[i].transform.position, pointsSpawnEnemy[i].transform.rotation);
        }
    }
}
