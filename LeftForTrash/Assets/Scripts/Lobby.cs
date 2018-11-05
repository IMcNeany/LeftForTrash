using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lobby : MonoBehaviour {

    public GameObject[] playerList;
    public GameObject[] tickList;
    public bool[] playerBool;
    private DataPersistance data;
    public  int playerCount;
    public Text startText;
    private SceneController scene;
    // Use this for initialization
    void Start ()
    {
        scene = GetComponent<SceneController>();
        startText.gameObject.SetActive(false);
        data = gameObject.GetComponent<DataPersistance>();
        playerList = GameObject.FindGameObjectsWithTag("Player");
        tickList = GameObject.FindGameObjectsWithTag("LobbyTick");
        for (int i = 0; i < playerList.Length; i++)
        {
            SpriteRenderer rend = playerList[i].GetComponent<SpriteRenderer>();
            rend.color = Color.black;
            tickList[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Start_1") && playerBool[3] == false)
        {
            SpriteRenderer rend = playerList[3].GetComponent<SpriteRenderer>();
            rend.color = Color.white;
            playerBool[3] = true;
            tickList[1].SetActive(true);
            playerCount += 1;
            data.setPlayer1Active(true);
        }

        if (Input.GetButtonDown("Start_2") && playerBool[0] == false)
        {
            SpriteRenderer rend = playerList[0].GetComponent<SpriteRenderer>();
            rend.color = Color.white;
            playerBool[0] = true;
            tickList[0].SetActive(true);
            playerCount += 1;
            data.setPlayer2Active(true);
        }

        if (Input.GetButtonDown("Start_3") && playerBool[1] == false)
        {
            SpriteRenderer rend = playerList[1].GetComponent<SpriteRenderer>();
            rend.color = Color.white;
            playerBool[1] = true;
            tickList[2].SetActive(true);
            playerCount += 1;
            data.setPlayer3Active(true);
        }

        if (Input.GetButtonDown("Start_4") && playerBool[2] == false)
        {
            SpriteRenderer rend = playerList[2].GetComponent<SpriteRenderer>();
            rend.color = Color.white;
            playerBool[2] = true;
            tickList[3].SetActive(true);
            playerCount += 1;
            data.setPlayer4Active(true);
        }

        if (playerCount >= 1)
        {
            startText.gameObject.SetActive(true);

            if (Input.GetButton("A_1") || Input.GetButton("A_2") || 
                Input.GetButton("A_3") || Input.GetButton("A_4"))
            {
                scene.NextScene();
            }
        }

        data.SetPlayerCount(playerCount);
    }
}
