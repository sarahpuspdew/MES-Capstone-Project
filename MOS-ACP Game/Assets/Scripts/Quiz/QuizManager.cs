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

    [SerializeField] GameObject[] options;
    [SerializeField] GameObject quizPanel;
    [SerializeField] GameObject barcodePanel;
    [SerializeField] TMP_Text questionText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int currentQuestion;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    int totalQuestions;
    int score;

    public List<QuestionAndAnswers> questions;

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
        //promptManager.EndPrompt();
        quizPanel.SetActive(false);
        barcodePanel.SetActive(true);
    }

    public void Correct()
    {
        AudioSource.PlayClipAtPoint(correctSound, transform.position);
        score += 1;
        questions.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void Wrong()
    {
        AudioSource.PlayClipAtPoint(wrongSound, transform.position);
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
            options[i].GetComponent<Image>().sprite = options[i].GetComponent<Answers>().startImage;
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
