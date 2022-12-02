using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public Prompt prompt;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            FindObjectOfType<PromptManager>().StartPrompt(prompt);
        }  
    }
}
