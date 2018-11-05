using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayers : MonoBehaviour {

    private GameObject gm;
    private DataPersistance data;
    public GameObject[] players;

    // Use this for initialization
    void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
        data = gm.GetComponent<DataPersistance>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (data.player1Active == true)
        {
            players[0].SetActive(true);
           // player_inputs[0] = players[0].GetComponent<InputManager>();
        }

        if (data.player2Active == true)
        {
            players[1].SetActive(true);
            //player_inputs[1] = players[1].GetComponent<InputManager>();
        }

        if (data.player3Active == true)
        {
            players[2].SetActive(true);
           // player_inputs[2] = players[2].GetComponent<InputManager>();
        }

        if (data.player4Active == true)
        {
            players[3].SetActive(true);
           // player_inputs[3] = players[3].GetComponent<InputManager>();
        }
    }
}
