using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Number : MonoBehaviour
{
    PickUpWeapon pickUp;

    private void Start()
    {
        pickUp = GameObject.FindWithTag("Player").GetComponent<PickUpWeapon>();
        pickUp.UpdatingWeapons();
    }
    public int number;
    bool ePress = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ePress)
        {
            collision.gameObject.GetComponent<PickUpWeapon>().weapon_Number = number;
            pickUp.UpdatingWeapons();
            
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        ePress = Input.GetKey(KeyCode.E);
    }

}
