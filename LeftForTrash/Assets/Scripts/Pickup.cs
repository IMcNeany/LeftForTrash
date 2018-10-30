using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //private UI_Elements ui_elements;
    public Transform prefab;

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
        if (collision.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);
            Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);

        }
    }

}

