
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBoss : MonoBehaviour
{
    private GameObject gm;
    public int player_count = 0;
    public GameObject[] players;
    public InputManager[] player_inputs;
    private int active_p;
    public GameObject text;
    public GameObject sc;
    private DataPersistance data;
    bool right, left, pause, move_boss;
    public GameObject boss;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
        data = gm.GetComponent<DataPersistance>();
        player_count = data.player_count;

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

        if (text.activeInHierarchy)
        {
            text.SetActive(false);
        }

        active_p = player_count;
        right = true;
        left = false;
    }

    private void Update()
    {
        if(right)
        {
            StartCoroutine(RunRight());
        }

        if(pause)
        {
            StartCoroutine(Pause());
        }

        if(move_boss)
        {
            boss.transform.position = Vector3.Lerp(boss.transform.position, new Vector3(boss.transform.position.x - 5, boss.transform.position.y, boss.transform.position.z), 0.5f * Time.deltaTime);
        }

        if(left)
        {
            StartCoroutine(RunLeft());
        }

        if (active_p == 0)
        {
            gameObject.GetComponent<FadeObject>().fadeIn = true;
            gameObject.GetComponent<FadeObject>().start = true;
            text.SetActive(true);
            StartCoroutine(EndScene());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        active_p--;
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(2.5f);
        text.SetActive(false);
        sc.GetComponent<SceneController>().NextScene();
    }

    IEnumerator RunRight()
    {
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
        yield return new WaitForSeconds(3.5f);
        right = false;
        pause = true;
        move_boss = true;
    }

    IEnumerator Pause()
    {
        if (data.player1Active == true)
        {
            player_inputs[0].setHorizontal(0);
        }
        if (data.player2Active == true)
        {
            player_inputs[1].setHorizontal(0);
        }
        if (data.player3Active == true)
        {
            player_inputs[2].setHorizontal(0);
        }
        if (data.player4Active == true)
        {
            player_inputs[3].setHorizontal(0);
        }
        yield return new WaitForSeconds(0.5f);
        pause = false;  
        left = true;
    }

    IEnumerator RunLeft()
    {
        if (data.player1Active == true)
        {
            player_inputs[0].setHorizontal(-1);
        }
        if (data.player2Active == true)
        {
            player_inputs[1].setHorizontal(-1);
        }
        if (data.player3Active == true)
        {
            player_inputs[2].setHorizontal(-1);
        }
        if (data.player4Active == true)
        {
            player_inputs[3].setHorizontal(-1);
        }
        yield return new WaitForSeconds(2.5f);
    }
}
