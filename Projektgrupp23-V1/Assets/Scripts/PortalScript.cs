using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    LevelLoader levelLoader;
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            levelLoader.LoadNextScene();
        }
    }
}
