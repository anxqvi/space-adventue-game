using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
   public AudioSource source;
   public AudioClip clip;
   public GameController gameController;

   public void Start()
   {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
   }
   public void Update()
   {
      if (gameController.selfDestruct == true)
      {
        source.PlayOneShot(clip);
      }
   }
  
}