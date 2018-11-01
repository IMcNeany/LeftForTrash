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

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
        player_count = gm.GetComponent<DataPersistance>().player_count;

        for (int i = 0; i < player_count; i++)
        {
            if(!players[i].activeInHierarchy)
            {
                players[i].SetActive(true);
            }
            player_inputs[i] = players[i].GetComponent<InputManager>();
        }

        if(text.activeInHierarchy)
        {
            text.SetActive(false);
        }
        active_p = player_count;
    }

    private void Update()
    {
        for (int i = 0; i < player_count; i++)
        {
            player_inputs[i].setHorizontal(1);
        }

        if(active_p == 0)
        {
            gameObject.GetComponent<FadeObject>().fadeIn = true;
            gameObject.GetComponent<FadeObject>().start = true;
            text.SetActive(true);
            StartCoroutine(delay());        
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
    }
}
