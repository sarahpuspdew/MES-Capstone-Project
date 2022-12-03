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
    public Color startColor;

    void Start()
    {
        startImage = GetComponent<Image>().sprite;   
    }

    public void Answer()
    {
        if (isCorrect) {
            //GetComponent<Image>().color = Color.green;
            GetComponent<Image>().sprite = correctImage; 
            Debug.Log("Correct Answer");
            quizManager.Correct();
        }
        else {
            //GetComponent<Image>().color = Color.red;
            GetComponent<Image>().sprite = falseImage; 
            Debug.Log("Wrong Answer");
            quizManager.Wrong();
        }
    }
}
