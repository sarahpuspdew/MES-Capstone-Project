using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class QuestionAndAnswers
    {
        public string question;
        public string[] answers;
        public int correctAnswer;
    }

    public List<QuestionAndAnswers> questions;
    public GameObject[] options;
    public GameObject quizPanel;
    public TMP_Text questionText;
    public TMP_Text scoreText;
    public int currentQuestion;
    int totalQuestions;
    int score;

    void Start()
    {
        totalQuestions = questions.Count;
        GenerateQuestion();
    }

    void Update()
    {
        scoreText.text = score + "/" + totalQuestions;
    }
    
    void EndQnA()
    {
        quizPanel.SetActive(false);
    }

    public void Correct()
    {
        score += 1;
        questions.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void Wrong()
    {
        questions.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        GenerateQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<Answers>().startColor;
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = questions[currentQuestion].answers[i];

            if (questions[currentQuestion].correctAnswer == i+1) {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if(questions.Count>0) {
            currentQuestion = Random.Range(0, questions.Count);
            questionText.text = questions[currentQuestion].question;

            SetAnswer();
        }
        else {
            Debug.Log("Out of Questions");
            EndQnA();
        }
    }
}
