using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public string GameOverScene = "GameOver";
    public string MainScene = "MainScene";
    public float GameOverDelay = 3;
    public uint PlayerScore { get; private set;} = 0;
    public static GameStateController Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void IncrementPlayerScore(uint scoreToAdd)
    {
        PlayerScore += scoreToAdd;
    }
    public void RestartGame()
    {
        PlayerScore = 0;
        SceneManager.LoadScene(MainScene);
    }
    public void OnPlayerDestroyed()
    {
        Invoke("OnGameOver", GameOverDelay);
    }

    private void OnGameOver()
    {
        SceneManager.LoadScene(GameOverScene);
    }
}
