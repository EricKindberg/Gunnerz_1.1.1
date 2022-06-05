using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore : MonoBehaviour
{
    public int score;
    TMPro.TextMeshProUGUI scoreText;
    void Start()
    {
        score = 0;
        if (GameObject.Find("PassableObject") != null)
        { 
            GameObject.Find("PassableObject").GetComponent<PassingScript>().GetScore();

        }
        scoreText = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
        UpdateScore();
    }
    public void addToScore(int points)
    {
        score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        TMPro.TextMeshProUGUI text = GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = "Score: " + score.ToString();
    }
}
