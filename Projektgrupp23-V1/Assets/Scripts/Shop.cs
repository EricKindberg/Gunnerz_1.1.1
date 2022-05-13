using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void BuyHealthPot()
    {
        GameObject player = GameObject.Find("Player");
        Pengar pengar = player.GetComponent<Pengar>();
        if (pengar.coins >= 500)
        {
            pengar.loseMoney(500);
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.Heal(5);
        }
    }

    public void BuyCoffee()
    {
        GameObject player = GameObject.Find("Player");
        Pengar pengar = player.GetComponent<Pengar>();
        if (pengar.coins >= 200)
        {
            pengar.loseMoney(200);
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            playerMovement.IncreaseMoveSpeed(0.2f);
        }
    }
}
