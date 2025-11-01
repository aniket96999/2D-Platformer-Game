using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AkDashboard : MonoBehaviour
{


    public GameObject[] stars; // Assign 3 star GameObjects in Inspector
    private int coinsCount;

    void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("coin").Length;
    }
public void Star(){

  int coinsLeft = GameObject.FindGameObjectsWithTag("coin").Length;
int coinsCollected = coinsCount - coinsLeft;

float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString()) * 100f;

if (percentage >= 33f && percentage < 66)
{
    // One star
    stars[0].SetActive(true);
}
else if (percentage >= 66 && percentage < 70)
{
    // Two stars
    stars[0].SetActive(true);
    stars[1].SetActive(true);
}
else if (percentage < 30 )
{
    
}
else
{
    // Three stars
    stars[0].SetActive(true);
    stars[1].SetActive(true);
    stars[2].SetActive(true);
}

}
}
