using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelPause;

    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }
}
