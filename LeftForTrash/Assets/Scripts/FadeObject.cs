using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    public bool start = false;
    private Color target_colour;
    public float alpha = 0;
    public bool fadeIn = false;

    private void Start()
    {
        target_colour = gameObject.GetComponent<SpriteRenderer>().material.color;
    }

    private void Update()
    {
        if(start)
        {
            if(fadeIn)
            {
                FadeIn();
            }
            else
            {
                FadeOut();
            }

            if (target_colour.a <= 0.0f)
            {
                target_colour.a = 0.0f;
                start = false;
            }
            if(target_colour.a >= 1.0f)
            {
                target_colour.a = 1.0f;
                start = false;
            }
        }

        alpha = target_colour.a;

        gameObject.GetComponent<SpriteRenderer>().material.color = target_colour;
    }

    private void FadeOut()
    {
        target_colour.a -= 1.0f * Time.deltaTime;
    }

    private void FadeIn()
    {
        target_colour.a += 1.0f * Time.deltaTime;
    }
}
