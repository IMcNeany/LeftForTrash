﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour {

    public enum ItemType
    {
        Health,
        Speed,
        Score
    };

    public bool triggerable;
    public ItemType type;
    public GameObject pickupAudioObject;
    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
        int random = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[random];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(triggerable)
        {
            if(collision.tag == "Player")
            {
                UseItem(collision.gameObject);
                GameObject audio_pickup = Instantiate(pickupAudioObject) as GameObject;
                StartCoroutine(DelayDespawn());
            }
        }
    }

    public void UseItem(GameObject player)
    {
        switch(type)
        {
            case ItemType.Health:
                player.GetComponent<PlayerCombat>().AddHealth(25);
                break;
            case ItemType.Speed:
                player.GetComponent<Movement>().BuffSpeed(3);
                break;
            case ItemType.Score:
                player.GetComponent<PlayerCombat>().score += 100;
                break;
        }
    }

    IEnumerator DelayDespawn()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
