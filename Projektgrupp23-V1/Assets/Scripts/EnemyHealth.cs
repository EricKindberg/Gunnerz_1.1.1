using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] int scoreValue = 10;
    public float health = 20;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioClip deathSound;
    private GameObject money;
    private Money pengar;
    [SerializeField] GameObject blood_Partical;

    void Start()
    {

    }

    public void TakingDamage(int damage)
    {
        health -= damage;
        if (GetComponentInChildren<HealthBar>() != null)
        {
            GetComponentInChildren<HealthBar>().hp = health;
        }
        
        Instantiate(blood_Partical, transform.position,Quaternion.identity);
       
        if (health <= 0)
        {
            Instantiate(GetMoney(), transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, 0.5f);

            try
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerScore>().addToScore(scoreValue);
            }
            catch
            {
                Debug.Log("Failed to add to score!");
            }

            gameObject.SetActive(false);
            Destroy(gameObject);
            
        }
        else
        {
            if (hitSound != null)
            {
                hitSound.Play();
            }
        }
        
    }

    GameObject GetMoney()
    {
        int random = Random.Range(0, 10);
        if (random < 5)
        {
            return Resources.Load("BronzePrefab") as GameObject;
        }
        else if (random < 8)
        {
            return Resources.Load("SilverPrefab") as GameObject;
        }
        else
        {
            return Resources.Load("GoldPrefab") as GameObject;
        }
    }
}
