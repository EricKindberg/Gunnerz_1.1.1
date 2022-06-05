using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingScript : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] int score;
    [SerializeField] int ammo;
    [SerializeField] float health;
    [SerializeField] int weaponID;
    [SerializeField] bool isLoaded = false;

    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        
    }

    public void Set()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>().Health;
        money = player.GetComponent<Money>().Amount;
        score = player.GetComponent<PlayerScore>().Score;
        GameObject gun = GameObject.FindGameObjectWithTag("ActiveWeapon");
        if (gun != null)
        {

            ammo = gun.GetComponent<FireSideWeapon>().Ammo;
        }
        weaponID = player.GetComponent<PickUpWeapon>().weaponID;
        isLoaded = true;
    }

    public void GetHealth()
    {
        if (isLoaded == false)
        {
            return;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Health = health;

    }

    public void GetMoney()
    {
        if (isLoaded == false)
        {
            return;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Money>().Amount = money;
    }

    public void GetScore()
    {
        if (isLoaded == false)
        {
            return;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>().Score = score;
    }
    public void GetWeapon()
    {
        if (isLoaded == false)
        {
            return;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<PickUpWeapon>().weaponID = weaponID;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PickUpWeapon>().UpdatingWeapons();

        GameObject gun = GameObject.FindGameObjectWithTag("ActiveWeapon");
        if (gun != null)
        {

            gun.GetComponent<FireSideWeapon>().Ammo = ammo;
        }
    }
}
