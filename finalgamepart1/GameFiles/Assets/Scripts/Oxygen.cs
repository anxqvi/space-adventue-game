using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oxygen : MonoBehaviour
{
  
   public float maxOxygen=5.0f;//variable for maximum oxygen value
   float oxygenRemaining;//variable to decrease the oxygen by the value of 10(default)
    public float oxygenDecreas;
   // public float oxygenIncrease=10f;
    public Slider slider;//variable for oxygen bar
  
    
    // Start is called before the first frame update
    void Start()
    {
        oxygenRemaining=maxOxygen;
        
      
    }

    // Update is called once per frame
    void Update()
    {
         
          
     if(oxygenRemaining>0)
     {
        oxygenRemaining-=Time.deltaTime;
         
         slider.value-=oxygenDecreas;
         GameLos();
     } 
    
     void GameLos()
     {
     if(slider.value<=0)
     {
        SceneManager.LoadScene("GameOver");
     } 
   }   
  
  
  }

}

