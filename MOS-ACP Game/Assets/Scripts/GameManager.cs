using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoader;
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        levelLoader.RestartLevel();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        levelLoader.MainMenu();
    }


}
