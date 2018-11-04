using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectList
{
    public List<GameObject> object_pool;
}

public class ObjectPooler : MonoBehaviour {

    public List<ObjectList> object_list;
    public List<GameObject> pooled_object_list;
	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public GameObject GetPooledObject(int obj_index)
    {
        for (int count = 0; count < object_list[obj_index].object_pool.Count; count++)
        {
            if (!object_list[obj_index].object_pool[count].activeSelf)
            {
                return object_list[obj_index].object_pool[count];
            }
        }

        GameObject obj = Instantiate(pooled_object_list[obj_index], transform.position, transform.rotation) as GameObject;
        object_list[obj_index].object_pool.Add(obj);

        return obj;
    }
}
