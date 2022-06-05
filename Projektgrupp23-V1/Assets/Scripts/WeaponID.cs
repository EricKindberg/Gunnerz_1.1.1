using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponID : MonoBehaviour
{
    PickUpWeapon pickUp;
    public int IDNumber;
    bool ePress = false;

    private void Start()
    {
        pickUp = GameObject.FindWithTag("Player").GetComponent<PickUpWeapon>();
        //pickUp.UpdatingWeapons();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(true);
        }
        if (collision.tag == "Player" && ePress)
        {

            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
            collision.gameObject.GetComponent<PickUpWeapon>().weaponID = IDNumber;

            pickUp.UpdatingWeapons();
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        ePress = Input.GetKey(KeyCode.E);
    }

}
