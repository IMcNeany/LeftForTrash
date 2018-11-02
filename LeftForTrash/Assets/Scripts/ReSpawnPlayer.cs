using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnPlayer : MonoBehaviour {
    public GameObject[] players;
    Vector3 pos;
    DataPersistance gameManager;

    // Use this for initialization
    void Start () {
       gameManager = GameObject.Find("GM").GetComponent< DataPersistance>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Movement>())
        {
            for (int i = 0; i < gameManager.player_count; i++)
            {
                if(i == 0)
                {
                   pos = new Vector3(gameObject.transform.position.x + 3, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                else if (i == 1)
                {
                    pos = new Vector3(gameObject.transform.position.x -3, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                else if(i == 2)
                {
                    pos = new Vector3(gameObject.transform.position.x + 3, gameObject.transform.position.y - 3, gameObject.transform.position.z);
                }
                else if(i == 3)
                {
                    pos = new Vector3(gameObject.transform.position.x -3, gameObject.transform.position.y - 3, gameObject.transform.position.z);
                }

                if (!players[i].activeSelf)
                {
                    players[i].transform.position = pos;
                    players[i].SetActive(true);
                }
            }
        }
    }
}
