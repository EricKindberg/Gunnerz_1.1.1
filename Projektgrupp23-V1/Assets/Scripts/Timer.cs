using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    TMPro.TextMeshProUGUI text;

    void Start()
    {
        timer = 0f;
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        text.text = System.Math.Round(timer, 2).ToString();
    }

    public void resetTimer()
    {
        timer = 0f;
    }

    
}
