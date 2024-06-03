using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiManage : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Sprite[] livesSprite;
    [SerializeField] private Image livesImage;
    [SerializeField] private Text gameOver;
    [SerializeField] private Text restartGame;
    [SerializeField] private SceneManagerScript gameManager;
    void Start()
    {
        scoreText.text = "Score : " + 0;
        gameOver.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<SceneManagerScript>();
        restartGame.gameObject.SetActive(false);

        if (gameManager==null)
        {
            Debug.LogError("SceneManager null Reference");
        }
    }
    
    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score : " + playerScore;
    }

    public void UpdateLives(int currentLives)
    {
        livesImage.sprite = livesSprite[currentLives];
        if (currentLives<1)
        {
            StartCoroutine(GameOverTextFlicker());
            gameManager.GameOver();
        }
        //display image sprite and giving it a now one based on current live index.
    }

    // public void GameOverText()
    // {
    //     gameOver.enabled = true;
    //     //Alternative gameOver.gameObject.SetActive(true);
    // }

    IEnumerator GameOverTextFlicker()
    {
        while (true)
        {
            gameOver.gameObject.SetActive(true);
            restartGame.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameOver.gameObject.SetActive(false);
            restartGame.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
