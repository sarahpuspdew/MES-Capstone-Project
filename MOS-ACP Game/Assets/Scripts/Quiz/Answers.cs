using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Sprite startImage;
    public Sprite correctImage;
    public Sprite falseImage;

    void Start()
    {
        startImage = GetComponent<Image>().sprite;   
    }

    public void Answer()
    {
        if (isCorrect) {
            GetComponent<Image>().sprite = correctImage; 
            Debug.Log("Correct Answer");
            quizManager.Correct();
        }
        else {
            GetComponent<Image>().sprite = falseImage; 
            Debug.Log("Wrong Answer");
            quizManager.Wrong();
        }
    }
}
