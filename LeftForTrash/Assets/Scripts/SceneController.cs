﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameObject game_controller;

    private void Start()
    {
        game_controller = GameObject.FindGameObjectWithTag("GameController");
    }

    private void ResetPassingData()
    {
        game_controller.GetComponent<DataPersistance>().FlushData();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MenuScene()
    {
        ResetPassingData();
        SceneManager.LoadScene(0);
    }
}
