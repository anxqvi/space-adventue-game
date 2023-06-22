using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;//impact effect for projectile
      private void OnCollisionEnter(Collision collision)
      {
        FindObjectOfType<AudioManager>().Play("Explosion");//To play an explosion sound when the projectile hitted 
        GameObject impact= Instantiate(impactEffect,transform.position,Quaternion.identity);//initialize the projectile
      
        Destroy(impact,2);//To destroy the impact effect after 2s
        Destroy(gameObject);//To destroy the projectile after hitting
      }
}
  