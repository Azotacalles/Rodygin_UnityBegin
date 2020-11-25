using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameEnding : MonoBehaviour
{
    private int enemies;
    private int playerHealth = 100;
    public CanvasGroup exitCanvas;
    public CanvasGroup restartCanvas;
    private float m_timer;
    public float fadeDuration = 1f;
    private bool win = false;
    private bool restart = false;
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
        if(gameObject.CompareTag("Player")) StartCoroutine(Health());
    }

    void Update()
    {
        if(playerHealth == 0)
        {
            print("GAME OVER!");
            restart = true;
        }

        if (win) EndGame(exitCanvas, false);
        if (restart) EndGame(restartCanvas, true);
        //if (enemies == 0)
        //    print("WIN!");
    }

    IEnumerator Health()
    {
        while (true)
        {
            playerHealth--;
            print(playerHealth);
            yield return new WaitForSeconds(1);
        } 
    }

    public void EndGame(CanvasGroup canvas, bool restart)
    {
        m_timer += Time.deltaTime;
        canvas.alpha = m_timer / fadeDuration;
        if (m_timer > fadeDuration + 1f)
        {
            if (restart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            win = true;
        }
    }
}
