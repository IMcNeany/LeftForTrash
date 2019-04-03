using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject[] triggers;
    public bool[] check;
    private GameObject gm;
    private int player_max;
    Vector3 spawn_pos = new Vector3(0,0,0);
    DataPersistance data;
    public GameObject[] players;

    public void Init()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
        player_max = gm.GetComponent<DataPersistance>().player_count;
        data = gm.GetComponent<DataPersistance>();

        if (data.player1Active == true)
        {
            check[0] = true;
        }

        if (data.player2Active == true)
        {
            check[1] = true;
        }

        if (data.player3Active == true)
        {
            check[2] = true;
        }

        if (data.player4Active == true)
        {
            check[3] = true;
        }
    }

    private void Update()
    {
        if(triggers[0].GetComponent<CheckPointTrigger>().hit)
        {
            spawn_pos = triggers[0].transform.position;
        }
        if (triggers[1].GetComponent<CheckPointTrigger>().hit)
        { 
            spawn_pos = triggers[1].transform.position;
        }
        if (triggers[2].GetComponent<CheckPointTrigger>().hit)
        {
            spawn_pos = triggers[2].transform.position;
        }

        for(int i = 0; i < player_max; i++)
        {
            if(players[i].GetComponent<PlayerCombat>().health <= 0)
            {
                players[i].GetComponent<PlayerCombat>().health = 100;
                players[i].transform.position = spawn_pos;
            }
        }
    }
}
