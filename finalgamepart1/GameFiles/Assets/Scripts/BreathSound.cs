using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathSound : MonoBehaviour
{
   public AudioSource breathSound;

   public AudioClip breating;

   public void Start()
   {
        takeBreath();
   }
   public void Upate()
   {
      takeBreath();
   }
   public void takeBreath()
   {
       breathSound.clip=breating;
       breathSound.Play();
   }
   
   
  
}
