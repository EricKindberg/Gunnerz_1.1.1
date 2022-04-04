using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;
    
     void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Enemy")
         {
             GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
             Destroy(effect, 0.25f);
             Destroy(gameObject);

             collision.gameObject.GetComponent<EnemyHealth>().TakingDamage(damage);
         }
         else if (collision.gameObject.tag == "Obstacle")
         {
             GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
             Destroy(effect, 0.25f);
             Destroy(gameObject);
         }
     }
    
    private void Update()
    {
        /*foreach (GameObject g in Scene)
        {

        }
        if(GetComponent<BoxCollider2D>().bounds.Intersects(other))*/
    }
}
