using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoney : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] int scoreValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Money money = FindObjectOfType<Money>();
            money.AddMoney(value);
            PlayerScore playerScore = FindObjectOfType<PlayerScore>();
            playerScore.AddToScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
