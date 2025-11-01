using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    AudioManager audioManager;
    public static PlayerManager Instance;
    public int coinCount = 0;
    public int totalCoinsInLevel = 0;

    void Awake()
    {
        Instance = this;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        totalCoinsInLevel = GameObject.FindGameObjectsWithTag("coin").Length;
    }
    public bool PickupItem(GameObject obj)
    {
        Debug.Log($"Pickup triggered by {obj.name}"); // 👈 Add this line

        switch (obj.tag)
        {
            case "coin":
                audioManager.PlaySFX(audioManager.checkpoint);
                coinCount++;
                ScoreManager.Instance.AddPoints(10);
                return true;

            case "question":
                audioManager.PlaySFX(audioManager.quest);
                Debug.Log("Picked question trigger.");
                return true;

            default:
                return false;
        }
    }



}
