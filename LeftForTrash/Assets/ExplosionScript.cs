using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    public float damage;
    public AnimationClip animation;

    private void Start()
    {
        Destroy(gameObject, animation.length);
    }
}
