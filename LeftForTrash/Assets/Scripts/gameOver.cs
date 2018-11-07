using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour {

    public List <GameObject> player;
    private bool gameOverset;
    private bool isPlayersAlive;
        // Use this for initialization

    void Start ()
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
		for (int i = 0; i < player.Count; i++)
        {
       
            if (player[i].GetComponent<PlayerCombat>().health >= 0)
            {
                    isPlayersAlive = true;
            }
        }

        for (int i = 0; i < player.Count; i++)
        {

            if (player[i].GetComponent<PlayerCombat>().health <= 0)
            {
                if (isPlayersAlive == true)
                {
                    gameOverset = false;
                }
                else
                {
                    gameOverset = true;
                }
            }
        }

        if (gameOverset == true)
        {
            endGame();
        }

    }

    void endGame()
    {
        SceneController sc = gameObject.GetComponent<SceneController>();
        sc.GameOver();
    }
}
