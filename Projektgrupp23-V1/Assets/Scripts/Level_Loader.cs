using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{

    int activeSceenIndex;
    bool inMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        activeSceenIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if(activeSceenIndex != 0)
        {
            if (inMenu == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 0;
                    Transform pauceMenu = FindObjectOfType<PauceMenu>().transform;
                    foreach (Transform child in pauceMenu)
                    {
                        child.gameObject.SetActive(true);
                    }
                    inMenu = true;
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    Time.timeScale = 0;
                    Transform shop = GameObject.Find("Shop").transform;

                    foreach (Transform child in shop)
                    {
                        child.gameObject.SetActive(true);
                    }
                    inMenu = true;
                }
            }
            
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Transform pauceMenu = FindObjectOfType<PauceMenu>().transform;
        Transform shop = GameObject.Find("Shop").transform;

        foreach (Transform child in pauceMenu)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in shop)
        {
            child.gameObject.SetActive(false);
        }
        inMenu = false;
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

    public void LoadGameOver()
    {
        Debug.Log("Load Game Over sreen");
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
