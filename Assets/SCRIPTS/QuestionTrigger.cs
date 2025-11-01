using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public GameObject questionPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            questionPanel.SetActive(true);
            Time.timeScale = 0f; // Pause game
            FindObjectOfType<QuestionManager>().StartQuestion();
        }
    }
}
