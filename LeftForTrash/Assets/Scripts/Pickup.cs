using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //private UI_Elements ui_elements;
    public Transform prefab;
    public int spawnTime = 1;
    void Awake()
    {
        //ui_elements = GameObject.FindObjectOfType<UI_Elements>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{

        //    Destroy(this.gameObject);
        //    StartCoroutine(Spawn());
        //    Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);


        //}
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime);
    }
}

