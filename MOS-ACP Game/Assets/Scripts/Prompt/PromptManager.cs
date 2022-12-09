using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PromptManager : MonoBehaviour
{
    [SerializeField] Interactor playerInteractor;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI promptText;
    [SerializeField] RectTransform promptPanel;
    [SerializeField] float typingSpeed = 0f;
    [SerializeField] Animator animator;
    Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        //promptPanel.localScale = new Vector3(0, 0);
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) {
            EndPrompt();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        promptText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            promptText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    public void StartPrompt(Prompt prompt)
    {
        animator.SetBool("isOpen", true);
        //Time.timeScale = 0;
        //promptPanel.localScale = new Vector3(0.9f, 0.35f);
        //nameText.text = prompt.name;

        sentences.Clear();

        foreach (string sentence in prompt.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void EndPrompt()
    {
        animator.SetBool("isOpen", false);
        playerInteractor.interactionPointRadius += 0.5f;
        //Time.timeScale = 1;
        //promptPanel.localScale = new Vector3(0, 0);
    }
}