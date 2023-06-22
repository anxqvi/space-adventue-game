using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame()//This method will load the main scene when the user click on the playButton in the main menu
  {
      SceneManager.LoadScene("Main");
  }
  public void menu()//This method will load the main menu scene when the user click on the main menu button 
  {
      SceneManager.LoadScene("MainMenu");
  }
  
  public void QuitGame()//this builtin function will quit the game using the quit button
  {
      Application.Quit();
    
  }
  
}
