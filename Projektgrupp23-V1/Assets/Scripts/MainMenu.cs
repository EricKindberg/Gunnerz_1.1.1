using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Lever1;
    public string OptionsMenu;
    public void StartGame() 
    {
        SceneManager.LoadScene(Lever1);
        Debug.Log("Starting");
    }
    public void OpenOptions()
    {
        SceneManager.LoadScene(OptionsMenu);
        Debug.Log("Opening options");
    }
    public void CloseOptions()
    {

    }
    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
