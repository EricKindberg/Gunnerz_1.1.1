using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 20;
    private Pengar pengar;

    public AudioSource hitSound;
    public AudioClip deathSound;

    void Start()
    {
        pengar = FindObjectOfType<Pengar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakingDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            pengar.addMoney(5);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, 0.5f);
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


}
