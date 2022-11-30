using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] RectTransform infoPanel;
    [SerializeField] float typingSpeed = 0f;
    //[SerializeField] Animator animator;
    Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        infoPanel.localScale = new Vector3(0, 0);
    }

    public void StartPrompt(Prompt prompt)
    {
        //animator.SetBool("isOpen", true);
        Time.timeScale = 0;
        infoPanel.localScale = new Vector3(1f, 0.5f);
        //nameText.text = prompt.name;

        sentences.Clear();

        foreach (string sentence in prompt.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
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
        infoText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            infoText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    void EndPrompt()
    {
        //animator.SetBool("isOpen", false);
        Time.timeScale = 1;
        infoPanel.localScale = new Vector3(0, 0);
    }
}