using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] private bool isGameOver;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver==true)
        {
            SceneManager.LoadScene("Scenes/GameScene");
        }if (Input.GetKeyDown(KeyCode.M) && isGameOver==true)
        {
            SceneManager.LoadScene("Scenes/MainMenuScene");
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
