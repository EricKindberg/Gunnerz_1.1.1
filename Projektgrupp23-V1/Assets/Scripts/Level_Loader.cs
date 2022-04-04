using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{

    int activeSceenIndex;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        activeSceenIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadMainMenu()
    {
        Debug.Log("Load main menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadNextScene()
    {
        Debug.Log("Load next scene");
        SceneManager.LoadScene(activeSceenIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
