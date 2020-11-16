using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameEnding : MonoBehaviour
{
    private int enemies;

    public int Enemies
    { 
        get { return enemies; }
        set { enemies = value; }
    }

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("PointSpawnEnemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies == 0)
            print("WIN!");
    }
}
