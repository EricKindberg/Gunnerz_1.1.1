using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public Money pengar;
    void Start()
    {
        pengar = FindObjectOfType<Money>();
    }

}
