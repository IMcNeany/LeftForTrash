using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Elements : MonoBehaviour
{
    [Header("Timer Values")]

    [SerializeField] private Text uiText;
    [SerializeField] private float seconds = 100.0f; //How many seconds
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    [Header("Timer Values")]

    public Text FPSText;
    private int frameRate;

    void Start()
    {
        timer = seconds;
    }

    void Update()
    {
        FPSCounter();
        GameTimer();
        FormatTimer();
    }

    private void GameTimer() 
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= 1 * Time.deltaTime;
            uiText.text = timer.ToString("F");
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
        }
    }

    private void FormatTimer() //Changes seconds to minutes
    {
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        uiText.text = "Time Left: " + minutes + " : " + seconds;
    }

    private void FPSCounter()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        frameRate = (int)current;
        FPSText.text = frameRate.ToString() + " FPS";
    }
}
