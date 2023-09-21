using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsGameOver { get; private set; }
    public bool IsGameClear { get; private set; }
    public GameObject gameOverText;
    public GameObject restartText;
    public TextMeshProUGUI scoreText;

    public GameObject gameClearText;

    public int score = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            gameOverText.SetActive(false);
            restartText.SetActive(false);
            gameClearText.SetActive(false);
        }
        else
        {
            Debug.LogWarning("GameManager instance already exists, destroying this one.");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if (IsGameOver && Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if (IsGameOver)
            return;

        score += newScore;
        scoreText.text = $"SCORE : {score}";
    }



    public void OnPlayerDead()
    {
        IsGameOver = true;
        gameOverText.SetActive(true);
        restartText.SetActive(true);
    }

    public void OnGameClear()
    {
        IsGameClear = true;
        gameClearText.SetActive(true);
    }

}
