using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
 private void OnTriggerEnter(Collider other)
  {
       SceneManager.LoadScene("GameWin");
  }
     public void reStart()
  {
       SceneManager.LoadScene("Level1Cutscene");
  }
   public void mainMenu()
  {
       SceneManager.LoadScene("MainMenu");
  }
   public void QuitGame()
  {
       Application.Quit();
       Debug.Log("Game Quit");
  }
}
