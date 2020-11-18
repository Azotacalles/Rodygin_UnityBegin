﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameEnding : MonoBehaviour
{
    private int enemies;
    private int playerHealth = 100;
    private float timer = 1;

    public int Enemies
    { 
        get { return enemies; }
        set { enemies = value; }
    }

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void Update()
    {
        if (playerHealth > 0)
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                timer = 1;
                playerHealth--;
                print(playerHealth);
            }
        }
        else print("GAME OVER!");

        if (enemies == 0)
            print("WIN!");
    }
}
