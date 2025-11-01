using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour
{
    public static int TotalQuestions = 0;
    public static int CorrectAnswers = 0;

    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public TextMeshProUGUI timerText;
    public GameObject questionPanel;

    private float timer = 30f;
    private bool isQuestionActive = false;

    private int correctAnswer;

    private enum Operation { Addition, Subtraction, Multiplication, Division }

    private void Update()
    {
        if (isQuestionActive)
        {
            timer -= Time.unscaledDeltaTime;
            timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString();

            if (timer <= 0)
            {
                EndQuestion(false);
            }
        }
    }

    public void StartQuestion()
    {
        timer = 30f;
        isQuestionActive = true;
        questionPanel.SetActive(true);
        GenerateRandomQuestion();
    }

    void GenerateRandomQuestion()
    {
        // Pick a random operation
        Operation operation = (Operation)Random.Range(0, 4);
        int a = 0, b = 0;

        // Determine values and answer based on operation
        switch (operation)
        {
            case Operation.Addition:
                a = Random.Range(1, 51);
                b = Random.Range(1, 51);
                correctAnswer = a + b;
                questionText.text = $"What is {a} + {b}?";
                break;

            case Operation.Subtraction:
                a = Random.Range(10, 100);
                b = Random.Range(1, a); // Ensure no negative answers
                correctAnswer = a - b;
                questionText.text = $"What is {a} - {b}?";
                break;

            case Operation.Multiplication:
                a = Random.Range(2, 13);
                b = Random.Range(2, 13);
                correctAnswer = a * b;
                questionText.text = $"What is {a} × {b}?";
                break;

            case Operation.Division:
                b = Random.Range(2, 13);
                correctAnswer = Random.Range(2, 13);
                a = b * correctAnswer; // Make sure it's divisible
                questionText.text = $"What is {a} ÷ {b}?";
                break;
        }

        // Set up answers
        int correctIndex = Random.Range(0, answerButtons.Length);
        HashSet<int> usedAnswers = new HashSet<int> { correctAnswer };

        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button btn = answerButtons[i];
            btn.onClick.RemoveAllListeners();

            if (i == correctIndex)
            {
                btn.GetComponentInChildren<TextMeshProUGUI>().text = correctAnswer.ToString();
                btn.onClick.AddListener(() => OnAnswerSelected(true));
            }
            else
            {
                int wrongAnswer = GenerateWrongAnswer(usedAnswers, correctAnswer);
                usedAnswers.Add(wrongAnswer);
                btn.GetComponentInChildren<TextMeshProUGUI>().text = wrongAnswer.ToString();
                btn.onClick.AddListener(() => OnAnswerSelected(false));
            }
        }
    }

    int GenerateWrongAnswer(HashSet<int> used, int correct)
    {
        int wrong;
        do
        {
            wrong = correct + Random.Range(-10, 11);
        } while (used.Contains(wrong) || wrong <= 0);

        return wrong;
    }

    void OnAnswerSelected(bool isCorrect)
    {
        EndQuestion(isCorrect);
    }

    void EndQuestion(bool correct)
    {
        isQuestionActive = false;
        questionPanel.SetActive(false);
        Time.timeScale = 1f;

        if (correct)
        {
            Debug.Log("Correct! Points awarded.");
            // ScoreManager.Instance.AddPoints(10);
        }
        else
        {
            Debug.Log("Wrong!");
        }

        UIhandler.instance.ShowLevelDialog(correct);
    }

   

}
