using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    //public TMP_InputField inputField;
    //public string playerName;

    public void StartGame()
    {
       SceneManager.LoadScene(1);
    }

    public void CreditGame()
    {
        Debug.Log("Credit: List of the game creator");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
