using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int Amount;

    UpdateMoney updateMoney;
    void Start()
    {
        Amount = 0;
        if (GameObject.Find("PassableObject") != null)
        {
            GameObject.Find("PassableObject").GetComponent<PassingScript>().GetMoney();
        }
        updateMoney = GameObject.Find("Shop").transform.Find("coinsBG").transform.Find("Money").transform.GetComponent<UpdateMoney>();
        updateMoney.UpdateMoneyInShop(Amount);
    }
    public void AddMoney(int aCoins)
    {
        Amount += aCoins;
        updateMoney.UpdateMoneyInShop(Amount);
    }
    public void RemoveMoney(int aCoins)
    {
        Amount -= aCoins;
        updateMoney.UpdateMoneyInShop(Amount);
    }
}
