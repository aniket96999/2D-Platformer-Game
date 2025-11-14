using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIhandler : MonoBehaviour
{
    public static UIhandler instance;

    [Header("UI Panels")]
    public GameObject LevelDialog;

    [Header("Feedback Images")]
    public GameObject winImage;
    public GameObject loseImage;

    [Header("Score UI")]
    public TMPro.TextMeshProUGUI scoreText;

    [Header("Star Images")]
    public GameObject star0;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        // Initialize score display at start
        if (ScoreManager.Instance != null)
            UpdateScoreUI(ScoreManager.Instance.GetScore());
    }

    public void UpdateScoreUI(int newScore)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + newScore.ToString();
    }

    public void ShowLevelDialog(bool isWin)
    {
        if (LevelDialog == null)
        {
            Debug.LogError("LevelDialog is not assigned in the Inspector!");
            return;
        }

        LevelDialog.SetActive(true);
        winImage.SetActive(isWin);
        loseImage.SetActive(!isWin);

        // ✅ Always update score text when showing dialog
        if (ScoreManager.Instance != null)
            UpdateScoreUI(ScoreManager.Instance.GetScore());

        if (isWin)
            ShowStars();
        else
            HideAllStars();
    }

    void ShowStars()
    {
        HideAllStars(); // reset first

        if (PlayerManager.Instance == null)
        {
            Debug.LogWarning("PlayerManager instance not found!");
            return;
        }

        int collected = PlayerManager.Instance.coinCount;
        int totalCoins = PlayerManager.Instance.totalCoinsInLevel;

        if (totalCoins <= 0)
        {
            Debug.LogWarning("No coins found in this level!");
            star0.SetActive(true);
            return;
        }

        // Prevent division by zero
        if (totalCoins == 0)
        {
            star0.SetActive(true);
            return;
        }

        float ratio = (float)collected / totalCoins;

        // Reset stars
        star0.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        // Star rating logic
        if (ratio >= 1f)
            star3.SetActive(true);
        else if (ratio >= 0.666f)
            star2.SetActive(true);
        else if (ratio > 0f)
            star1.SetActive(true);
        else
            star0.SetActive(true);

    }
        void HideAllStars()
        {
            star0.SetActive(false);
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    
    public void RestartLevel()
    {

        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ResetScore(); // Reset score

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

    }

    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes in build settings. Looping to first scene.");
            SceneManager.LoadScene(0);
        }
    }

    
    public void LoadPrevLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int prevIndex = currentIndex - 1;

        if (prevIndex >= 0)
        {
            SceneManager.LoadScene(prevIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes in build settings. Looping to first scene.");
            SceneManager.LoadScene(0);
            
        }
    }
}
