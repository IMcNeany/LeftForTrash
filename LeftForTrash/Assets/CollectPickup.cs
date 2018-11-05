using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPickup : MonoBehaviour
{
    private UI_Elements ui_elements;

    [Header("Despawn")]
    public int despawnTime = 5;

    // Use this for initialization
    void Start()
    {
        ui_elements = GameObject.FindObjectOfType<UI_Elements>();
        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Player 1":
                collision.GetComponent<PlayerCombat>().score += 100;
                break;
            case "Player 2":
                collision.GetComponent<PlayerCombat>().score += 100;
                break;
            case "Player 3":
                collision.GetComponent<PlayerCombat>().score += 100;
                break;
            case "Player 4":
                collision.GetComponent<PlayerCombat>().score += 100;
                break;
        }

            Destroy(this.gameObject);
        //if (collision.gameObject.tag == "Player")
        //{
        //    ui_elements.score += 100;
        //}
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(this.gameObject);
    }
}
