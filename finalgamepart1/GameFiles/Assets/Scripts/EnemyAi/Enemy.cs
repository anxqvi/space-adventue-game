using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHP=100;//Enemy health variable
    public GameObject projectile;//a reference for the projectile prefab
    public Transform projectilePoint;//this is be the point from where the projectile should be instantiating
    
    public Animator animator;
   public  void Shoot()//method to perform the shooting functionality for the player
   {
        Rigidbody rb=Instantiate(projectile,projectilePoint.position,Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*30f,ForceMode.Impulse);
        rb.AddForce(transform.up*7,ForceMode.Impulse);
   }
   public void TakeDamage(int damageAmount)// Damage health method for the enemy
   {
     
     enemyHP-=damageAmount;//Decrease the enemy health by amount of enemy damage Amount
     if(enemyHP<=0)//check if the enemy health equals to zero then our enemy is dead       

    {
        animator.SetTrigger("death");
        GetComponent<CapsuleCollider>().enabled=false;
    }
    else
    {
        animator.SetTrigger("damage");
    }


   
   }
}
