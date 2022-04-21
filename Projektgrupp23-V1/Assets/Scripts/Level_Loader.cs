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

    private void Update()
    {
        if(activeSceenIndex != 0)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                Transform pauceMenu = FindObjectOfType<PauceMenu>().transform;
                foreach(Transform child in pauceMenu)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Transform pauceMenu = FindObjectOfType<PauceMenu>().transform;
        foreach (Transform child in pauceMenu)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void LoadMainMenu()
    {
        Debug.Log("Load main menu");
        Time.timeScale = 1;
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
