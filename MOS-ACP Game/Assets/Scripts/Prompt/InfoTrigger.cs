using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTrigger : MonoBehaviour
{
    public Prompt prompt;

    public void TriggerInfo()
    {
        FindObjectOfType<InfoManager>().StartPrompt(prompt);
    }
}