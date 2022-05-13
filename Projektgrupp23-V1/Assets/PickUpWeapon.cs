using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public int weapon_Number;
  
    public void UpdatingWeapons()
    {
        if (weapon_Number == -1)
        {
            return;
        }
        GameObject.Find("Red_Solider_light_RightHand").transform.GetChild(weapon_Number).gameObject.SetActive(true);

        for (int i = 0; i < 13; i++)
        {
            if (i == weapon_Number)
            {

                continue;
            }


            GameObject.Find("Red_Solider_light_RightHand").transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
