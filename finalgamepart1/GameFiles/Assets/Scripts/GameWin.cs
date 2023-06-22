using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public string currentScene;
    public GameController gameController;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Level2")
        {
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (currentScene == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }

        if (currentScene == "Level2" && gameController.selfDestruct == true)
        {
            SceneManager.LoadScene("GameWin");
        }
    }
}
