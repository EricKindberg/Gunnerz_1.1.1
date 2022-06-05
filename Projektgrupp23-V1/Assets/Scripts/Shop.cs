using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : GamePauser
{
    private void Update()
    {
        if (activeSceenIndex != 0)
        {
            if (inMenu == false)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    Time.timeScale = 0;
                    Transform shop = GameObject.Find("Shop").transform;

                    foreach (Transform child in shop)
                    {
                        child.gameObject.SetActive(true);
                    }
                    inMenu = true;
                }
            }

        }
    }

    public void BuyHealthPot()
    {
        GameObject player = GameObject.Find("Player");
        Money money = player.GetComponent<Money>();
        if (money.Amount >= 500)
        {
            money.RemoveMoney(500);
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.Heal(5);
        }
    }

    public void BuyCoffee()
    {
        GameObject player = GameObject.Find("Player");
        Money money = player.GetComponent<Money>();
        if (money.Amount >= 200)
        {
            money.RemoveMoney(200);
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            playerMovement.IncreaseMoveSpeed(1f);
        }
    }
}
