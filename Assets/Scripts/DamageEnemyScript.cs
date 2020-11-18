using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyScript : MonoBehaviour
{
    private int health = 100;
    private MyGameEnding gameEnding;
    
    public int Health
    {
        set { health = value; }
        get { return health; }
    }

    private void Start()
    {
        gameEnding = GameObject.FindGameObjectWithTag("Player").GetComponent<MyGameEnding>();
    }

    void Update()
    {
        if(health <= 0)
        {
            gameEnding.Enemies--;
            Destroy(gameObject);
        }
    }
}
