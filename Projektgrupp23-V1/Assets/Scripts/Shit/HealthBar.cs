using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Image health_Point;
    [SerializeField] Image backGround_Image;
    public float hp;
    private float max_Hp = 200;
    private float hurt_Speed = 0.004f;
    void Start()
    {
        hp = max_Hp;
    }

    
    void Update()
    {
        try
        {
            health_Point.fillAmount = hp / max_Hp;
            if (backGround_Image.fillAmount > health_Point.fillAmount)
            {
                backGround_Image.fillAmount -= hurt_Speed;
            }
            else
            {
                backGround_Image.fillAmount = health_Point.fillAmount;
            }
        }
        catch (System.Exception)
        {

            
        }
       
    }
}
