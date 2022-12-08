using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #elif (UNITY_STANDALONE)
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("about:blank");
        #endif
    }
}
