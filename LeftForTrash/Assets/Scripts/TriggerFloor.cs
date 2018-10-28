using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFloor : MonoBehaviour
{
    public GameObject floor00;
    public GameObject floor01;

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (floor00.activeInHierarchy)
            {
                floor00.SetActive(false);
                floor01.SetActive(true);
            }
            else if (floor01.activeInHierarchy)
            {
                floor01.SetActive(false);
                floor00.SetActive(true);
            }
        }
    }
}
