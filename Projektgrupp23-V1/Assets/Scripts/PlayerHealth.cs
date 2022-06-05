using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public float health;
    public Slider mSlider;
    private Animator animator;
    [SerializeField] GameObject playerDieExplotion;
    public float healthDamageAnimation;
    void Start()
    {
        health = maxHealth;
        if (GameObject.Find("PassableObject") != null)
        {
            GameObject.Find("PassableObject").GetComponent<PassingScript>().GetHealth();
        }
        UpdateHealthBar();
        animator = GetComponent<Animator>();
         healthDamageAnimation = health;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }*/ //Används denna????

    private void UpdateHealthBar()
    {
        float precentageHealth = (float)health / (float)maxHealth;
        float sliderValue = precentageHealth * 3.5f;
        mSlider.value = sliderValue;
    }
    IEnumerator GettingHurt(float hurtAnimationDelay)
    {
        animator.Play("Red_Solider_light_Hurt");
        yield return new WaitForSeconds(hurtAnimationDelay);
        healthDamageAnimation = health;
    }
    private void Update()
    {
        if (healthDamageAnimation > health)
        {

            StartCoroutine(GettingHurt(.7f));
        }
        else
        {
            animator.Play("Red_Solider_light_Walking");
        }

    }
    public void TakeDamage(float damage)
    {
        //Debug.Log(health);
       
        health -= damage;
      

        UpdateHealthBar();
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die() 
    {
        Instantiate(playerDieExplotion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        animator.Play("DieAnimation");
        yield return new WaitForSeconds(1.1f);
        FindObjectOfType<LevelLoader>().LoadGameOver();
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
