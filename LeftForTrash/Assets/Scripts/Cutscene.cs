﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    private GameObject gm;
    public int player_count = 0;
    public GameObject[] players;
    public InputManager[] player_inputs;
    private int active_p;
    public GameObject text;
    public GameObject sc;
    private DataPersistance data;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
        //scene.gameObject.GetComponent<SceneController>();
        player_count = gm.GetComponent<DataPersistance>().player_count;
        data = gm.GetComponent<DataPersistance>();

        if (data.player1Active == true)
        {
            players[0].SetActive(true);
            player_inputs[0] = players[0].GetComponent<InputManager>();
        }

        if (data.player2Active == true)
        {
            players[1].SetActive(true);
            player_inputs[1] = players[1].GetComponent<InputManager>();
        }

        if (data.player3Active == true)
        {
            players[2].SetActive(true);
            player_inputs[2] = players[2].GetComponent<InputManager>();
        }

        if (data.player4Active == true)
        {
            players[3].SetActive(true);
            player_inputs[3] = players[3].GetComponent<InputManager>();
        }


        //for (int i = 0; i < player_count; i++)
        //{
        //    if(!players[i].activeInHierarchy)
        //    {
        //        players[i].SetActive(true);
        //    }
        //    player_inputs[i] = players[i].GetComponent<InputManager>();
        //}

        if (text.activeInHierarchy)
        {
            text.SetActive(false);
        }
        active_p = player_count;
    }

    private void Update()
    {
        //for (int i = 0; i < player_count; i++)
        //{
        //    player_inputs[i].setHorizontal(1);
        //}

        if (data.player1Active == true)
        {
            player_inputs[0].setHorizontal(1);
        }
        if (data.player2Active == true)
        {
            player_inputs[1].setHorizontal(1);
        }
        if (data.player3Active == true)
        {
            player_inputs[2].setHorizontal(1);
        }
        if (data.player4Active == true)
        {
            player_inputs[3].setHorizontal(1);
        }


        if (active_p == 0)
        {
            gameObject.GetComponent<FadeObject>().fadeIn = true;
            gameObject.GetComponent<FadeObject>().start = true;
            text.SetActive(true);
            StartCoroutine(delay());
           // StartCoroutine(Load());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        active_p--;
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2.5f);
        text.SetActive(false);
        sc.GetComponent<SceneController>().NextScene();
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(4f);
       // scene.NextScene();
    }
}
