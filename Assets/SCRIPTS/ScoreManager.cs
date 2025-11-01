using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ✅ keep between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        UIhandler.instance?.UpdateScoreUI(score); // ✅ update UI live
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        UIhandler.instance?.UpdateScoreUI(score); // reset UI display
    }
}
