using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengar : MonoBehaviour
{
    // Start is called before the first frame update
    public int coins;
    public UpdateMoney updateMoney;
    void Start()
    {
        coins = 10000;

        updateMoney = GameObject.Find("Shop").transform.Find("coinsBG").transform.Find("Money").transform.GetComponent<UpdateMoney>();
        updateMoney.UpdateMoneyInShop(coins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addMoney(int aCoins)
    {
        coins += aCoins;
        updateMoney.UpdateMoneyInShop(coins);
    }
    public void loseMoney(int aCoins)
    {
        coins -= aCoins;
        updateMoney.UpdateMoneyInShop(coins);
    }
}
