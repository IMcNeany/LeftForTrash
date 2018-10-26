using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public List<GameObject> target_list = new List<GameObject> { null };
    public Vector3 origin = new Vector3(0, 0, -10);
    [HideInInspector]
    public bool lerp_movement = false;

    [HideInInspector]
    public float position_speed = 1.0f;
    [HideInInspector]
    public float size_speed = 1.0f;
    [HideInInspector]
    public float max_size = 50.0f;
    [HideInInspector]
    public float min_size = 5.0f;

    private float max_distance = 0.0f;
    private float camera_scale = 5.0f;
    private Camera camera_component;

    public void Start()
    {
        camera_component = GetComponent<Camera>();
        camera_scale = camera_component.orthographicSize;
    }
    public void Update()
    {
        UpdateCameraPosition();
        UpdateCameraSize();
    }

    public void UpdateCameraPosition()
    {
        Vector3 camera_position = GetTargetPosition();
        if (lerp_movement)
        {
            camera_position = Vector3.Lerp(camera_position, GetTargetPosition(), position_speed * Time.deltaTime);
        }

        camera_position.z = -10;
        transform.position = camera_position;
    }

    public Vector3 GetTargetPosition()
    {
        Vector3 center_position = Vector3.zero;
        for(int i = 0; i < target_list.Count; i++)
        {
            Vector3 target_position = target_list[i].transform.position;
            center_position += target_position;
        }
        return center_position / target_list.Count;
    }

    public void UpdateCameraSize()
    {
        bool shrink = true;
        float shrink_distance = 0;

        for (int i = 0; i < target_list.Count; i++)
        {
            Vector3 target_position = target_list[i].transform.position;
            
            for (int y = 0; y < target_list.Count; y++)
            {
                Vector3 next_target_position = target_list[y].transform.position;
                float current_distance = Vector3.Distance(target_position, next_target_position);
                if(current_distance > shrink_distance)
                {
                    shrink_distance = current_distance;
                }

                if (current_distance > max_distance)
                {
                    shrink = false;
                    max_distance = current_distance;
                }
            }
        }
        if (shrink)
        {
            max_distance = shrink_distance;
        }

        camera_scale = max_distance / 2;
        camera_scale = Mathf.Clamp(camera_scale, min_size, max_size);
        camera_component.orthographicSize = Mathf.Lerp(camera_component.orthographicSize, camera_scale, size_speed * Time.deltaTime);
    }
}
