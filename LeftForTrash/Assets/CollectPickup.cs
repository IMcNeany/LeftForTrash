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
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            ui_elements.score += 100;
        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(this.gameObject);
    }
}
