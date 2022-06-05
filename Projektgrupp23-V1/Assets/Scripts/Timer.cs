using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer;
    public float GetTimer
    {
        get => timer;
        set => timer = value;
    }
    TMPro.TextMeshProUGUI text;

    void Start()
    {
        timer = 0f;
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        text.text = System.Math.Round(timer, 2).ToString();
    }

    public void ResetTimer()
    {
        timer = 0f;
    }

    
}
