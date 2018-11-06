using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public enum ItemType
    {
        Health,
        Speed,
        Score
    };

    public bool triggerable;
    public ItemType type;

	// Use this for initialization
	void Start () {
		
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
                Destroy(gameObject);
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

}
