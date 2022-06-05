using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public int weaponID; // every weapon has it's own number ID .
    private const int totalWeapon = 13;
    public void UpdatingWeapons()
    {
        if (weaponID == -1)
        {
            return;
        }
        GameObject.Find("Red_Solider_light_RightHand").transform.GetChild(weaponID).gameObject.SetActive(true);
        GameObject.Find("Red_Solider_light_RightHand").transform.GetChild(weaponID).gameObject.GetComponent<FireSideWeapon>().SetAmmo();
        GameObject.Find("Red_Solider_light_RightHand").transform.GetChild(weaponID).gameObject.tag = "ActiveWeapon";
        for (int i = 0; i < totalWeapon; i++)
        {
            if (i == weaponID)
            {

                continue;
            }
            GameObject.Find("Red_Solider_light_RightHand").transform.GetChild(i).gameObject.SetActive(false);
            GameObject.Find("Red_Solider_light_RightHand").transform.GetChild(i).gameObject.tag = "NonActiveWeapon";

        }
    }
}
