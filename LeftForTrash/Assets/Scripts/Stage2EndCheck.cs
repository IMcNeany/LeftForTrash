using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2EndCheck : MonoBehaviour
{
    private GameObject gm;
    public int p_count = 0;
    private bool test = true;
    private bool end = false;
    private bool p1 = false;
    private bool p2 = false;
    private bool p3 = false;
    private bool p4 = false;
    public GameObject fade;
    private SceneController sc;
    public GameObject[] objectives;
    public int objective_count = 4;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
        p_count = gm.GetComponent<DataPersistance>().player_count;
        sc = gameObject.GetComponent<SceneController>();
    }

    private void Update()
    {
        if(test && objective_count == 0)
        {
            switch (p_count)
            {
                case 1:
                    if(p1)
                    {
                        end = true;
                    }
                    break;
                case 2:
                    if (p1 && p2)
                    {
                        end = true;
                    }
                    break;
                case 3:
                    if (p1 && p2 && p3)
                    {
                        end = true;
                    }
                    break;
                case 4:
                    if (p1 && p2 && p3 && p4)
                    {
                        end = true;
                    }
                    break;
            }
            if(end)
            {
                //fade 
                fade.GetComponent<FadeObject>().fadeIn = true;
                fade.GetComponent<FadeObject>().start = true;
                //wait
                StartCoroutine(delay());
                    //move scene
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            test = true;
        }
        else
        {
            test = false;
        }
        switch (collision.gameObject.name)
        {
            case "Player 1":
                p1 = true;
                break;
            case "Player 2":
                p2 = true;
                break;
            case "Player 3":
                p3 = true;
                break;
            case "Player 4":
                p4 = true;
                break;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Player 1":
                p1 = false;
                break;
            case "Player 2":
                p2 = false;
                break;
            case "Player 3":
                p3 = false;
                break;
            case "Player 4":
                p4 = false;
                break;
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2.5f);
        sc.NextScene();
    }
}
