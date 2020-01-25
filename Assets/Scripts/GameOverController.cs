using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void OnRestart()
    {
        GameStateController.Instance.RestartGame();
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
