using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public List<GameObject> object_pool;
    public GameObject pooled_object;
	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public GameObject GetPooledObject()
    {
        for (int count = 0; count < object_pool.Count; count++)
        {
            if (!object_pool[count].activeSelf)
            {
                return object_pool[count];
            }
        }

        GameObject obj = Instantiate(pooled_object, transform.position, transform.rotation) as GameObject;
        object_pool.Add(obj);

        return obj;
    }
}
