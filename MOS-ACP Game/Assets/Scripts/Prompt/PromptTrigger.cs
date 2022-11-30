using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptTrigger : MonoBehaviour
{
    public Prompt prompt;

    public void TriggerPrompt()
    {
        FindObjectOfType<PromptManager>().StartPrompt(prompt);
    }
}