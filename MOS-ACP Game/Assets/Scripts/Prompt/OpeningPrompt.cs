using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningPrompt : MonoBehaviour
{
    [SerializeField] PromptTrigger promptTrigger;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        promptTrigger.TriggerPrompt();
    }
}
