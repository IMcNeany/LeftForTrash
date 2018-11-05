using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePickUp : MonoBehaviour
{
    public GameObject exit_script;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        exit_script.GetComponent<Stage2EndCheck>().objective_count--;
        Destroy(this.gameObject);
    }
}
