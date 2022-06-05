using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public List<Transform> highscoreTransformList;
    public Transform elements;
    public Transform highScoreElement;
    public PlayerScore playerScore;

    public void Awake()
    {
        elements = transform.Find("Elements");
        highScoreElement = elements.Find("HighScoreElement");

        highScoreElement.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("HighScoresTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //highscores.highscoreList.Clear();
        //PlayerPrefs.DeleteAll();


        if (highscores == null)
        {
            AddHighscore(0, "Cesar");
            AddHighscore(0, "Eric");
            AddHighscore(0, "Basel");
            AddHighscore(0, "Cassandra");
            
            jsonString = PlayerPrefs.GetString("HighScoresTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        if (highscores.highscoreList.Count > 7)
        {
            for (int h = highscores.highscoreList.Count; h > 7; h--)
            {
                highscores.highscoreList.RemoveAt(7);
            }
        }
        for (int i = 0; i < highscores.highscoreList.Count; i++)
        {
            for (int j = 0; j < highscores.highscoreList.Count; j++)
            {
                if (highscores.highscoreList[j].score > highscores.highscoreList[i].score)
                {
                    HighscoreEntry newHighscore = highscores.highscoreList[i];
                    highscores.highscoreList[i] = highscores.highscoreList[j];
                    highscores.highscoreList[j] = newHighscore;
                }
            }
        }
        highscoreTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in highscores.highscoreList)
        {
            CreateHighscoreTransform(highscoreEntry, elements, highscoreTransformList);
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }

    }

     public void CreateHighscoreTransform(HighscoreEntry highscoreEntry,Transform element, List<Transform> transformList)
    {
        float height = 31f;
        Transform transform = Instantiate(highScoreElement, element);
        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, -height * transformList.Count);
        transform.gameObject.SetActive(true);

        int score = highscoreEntry.score;
        string name = highscoreEntry.name;
        int rank = transformList.Count + 1;
        transform.Find("Name").GetComponent<Text>().text = name;
        transform.Find("Rank").GetComponent<Text>().text = rank.ToString();
        transform.Find("Score").GetComponent<Text>().text = score.ToString();

        transformList.Add(transform);
    }

    public class Highscores
    {
        public List<HighscoreEntry> highscoreList;
    }
    public void AddHighscore(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("HighScoresTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if (highscores == null)
        {
            highscores = new Highscores()
            {
                highscoreList = new List<HighscoreEntry>()
            };
        }
        highscores.highscoreList.Add(highscoreEntry);
        if (highscores.highscoreList.Count > 7)
        {
            for (int h = highscores.highscoreList.Count; h > 7; h--)
            {
                highscores.highscoreList.RemoveAt(7);
            }
        }
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("HighScoresTable", json);
        PlayerPrefs.Save();
    }
    [System.Serializable]
    public class HighscoreEntry
    {
        public int score;
        public string name;
    }
        
}
