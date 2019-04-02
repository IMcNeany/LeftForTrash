using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBossScene : MonoBehaviour {

    public List<GameObject> enemies;
    public SceneController sc;
    bool enemyAlive = false;
    bool gameOverset = true;
    // Use this for initialization
    void Start () {
        Invoke("AddEnemies", 0.5f);
	}
    void AddEnemies()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (enemy.activeInHierarchy == true)
            {
                enemies.Add(enemy);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        float deadPlayers = 0;
        for (int i = 0; i < enemies.Count; i++)
        {

            if (enemies[i].GetComponent<PlayerCombat>().health >= 0)
            {
                enemyAlive = true;
            }
            if (enemies[i].GetComponent<PlayerCombat>().health <= 0)
            {
                enemyAlive = false;
                deadPlayers++;

            }

            if (enemyAlive == true)
            {
                gameOverset = false;
            }
            else if (deadPlayers == enemies.Count)
            {
                gameOverset = true;
            }
        }

        if (gameOverset == true)
        {
            endGame();
        }

    }

    void endGame()
    {
        sc = FindObjectOfType<SceneController>();
        sc.MenuScene();
    }
}
