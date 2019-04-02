using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour {

    public List <GameObject> player;
    public SceneController sc;
    private bool gameOverset;
    private bool isPlayersAlive = false;
        // Use this for initialization

    void Start ()
    {
        Invoke("FindPlayers", 0.5f);
	}
    void FindPlayers()
    {
        foreach (GameObject players in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (players.activeInHierarchy == true)
            {
                player.Add(players);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        float deadPlayers = 0;
		for (int i = 0; i < player.Count; i++)
        {
       
            if (player[i].GetComponent<PlayerCombat>().health >= 0)
            {
                    isPlayersAlive = true;
            }
            if (player[i].GetComponent<PlayerCombat>().health <= 0)
            {
                isPlayersAlive = false;
                deadPlayers++;

            }

            if (isPlayersAlive == true)
            {
                gameOverset = false;
            }
            else if(deadPlayers == player.Count)
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
        sc.GameOver();
    }
}
