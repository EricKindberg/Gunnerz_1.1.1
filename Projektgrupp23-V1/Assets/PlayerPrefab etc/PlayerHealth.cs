using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public Slider mSlider;


    void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogWarning("Start");
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
            Debug.Log("Damage");
        }
    }

    private void UpdateHealthBar()
    {
        float precentageHealth = (float)health / (float)maxHealth;
        float sliderValue = precentageHealth * 3.5f;
        mSlider.value = sliderValue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        //Debug.Log(health);
        health -= damage;
        UpdateHealthBar();
        if (health <= 0)
        {
            FindObjectOfType<Level_Loader>().LoadGameOver();
        }
    }


    public void Heal(int amountHealed)
    {
        health += amountHealed;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthBar();
    }
}
