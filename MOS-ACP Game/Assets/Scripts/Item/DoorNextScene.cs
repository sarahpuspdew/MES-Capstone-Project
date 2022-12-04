using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNextScene : MonoBehaviour, IInteractable
{
    [SerializeField] PromptTrigger promptTrigger;
    [SerializeField] LevelLoader levelLoader;
    [SerializeField] string prompt;
    [SerializeField] int neededItems;
    
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        var playerInventory = interactor.GetComponent<PlayerInventory>();

        if (playerInventory.collectibleItems >= neededItems) {
            levelLoader.LoadNextLevel();
        }
        else {
            //Debug.Log("Collect more badge!!");
            promptTrigger.TriggerPrompt();
            return true;
        }
        return false;
    }
}