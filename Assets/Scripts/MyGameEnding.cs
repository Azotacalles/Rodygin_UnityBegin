using System.Collections;
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

    public int PlayerHealth
    {
        set 
        {
            playerHealth = Mathf.Clamp(value, 0 , 100);
        }
        get { return playerHealth; }
    }

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemies += GameObject.FindGameObjectsWithTag("PointSpawnEnemy").Length;
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
               // print(playerHealth);
            }
        }
        else
        {
            print("GAME OVER!");
            transform.position = new Vector3(-28, 0, 41);
            playerHealth = 100;
        }

        if (enemies == 0)
            print("WIN!");
    }
}
