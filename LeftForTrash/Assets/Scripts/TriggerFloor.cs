using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFloor : MonoBehaviour
{
    public GameObject floor;

    public void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (floor.activeInHierarchy)
            {
                floor.SetActive(false);
            }
            else
            {
                floor.SetActive(true);
            }
        }
    }
}
