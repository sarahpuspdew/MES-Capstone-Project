using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoFrame : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject descPanel;
    [SerializeField] string prompt;
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Time.timeScale = 0;
        descPanel.SetActive(true);
        return true;
    }

    public void ClosePanel()
    {
        Time.timeScale = 1;
        descPanel.SetActive(false);
    }
}