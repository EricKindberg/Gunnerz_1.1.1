using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore : MonoBehaviour
{
    public int Score;
    TMPro.TextMeshProUGUI scoreText;
    void Start()
    {
        Score = 0;
        if (GameObject.Find("PassableObject") != null)
        { 
            GameObject.Find("PassableObject").GetComponent<PassingScript>().GetScore();
        }
        scoreText = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
        UpdateScore();
    }
    public void AddToScore(int points)
    {
        Score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + Score.ToString();
    }
}
