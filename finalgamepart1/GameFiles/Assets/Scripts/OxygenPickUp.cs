using UnityEngine;
using UnityEngine.UI;


public class OxygenPickUp : MonoBehaviour
{

public float oxygenIncrease;

public Slider sliders;//variable for oxygen bar
 
 private void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player"))
    {
           // Debug.Log("We HIt a health");
            sliders.value+=oxygenIncrease;
            Destroy(gameObject);
    }
  }

  
  
}
