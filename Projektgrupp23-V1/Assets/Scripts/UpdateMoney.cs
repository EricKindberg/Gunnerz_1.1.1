using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMoney : MonoBehaviour
{
    public void UpdateMoneyInShop(int aMoney)
    {
        TMPro.TextMeshProUGUI text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = aMoney.ToString();
    }
}
