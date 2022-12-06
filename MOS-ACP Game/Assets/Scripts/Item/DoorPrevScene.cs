using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPrevScene : MonoBehaviour, IInteractable
{
    [SerializeField] LevelLoader levelLoader;
    [SerializeField] string prompt;
    
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        levelLoader.LoadPrevLevel();
        return true;
    }
}
