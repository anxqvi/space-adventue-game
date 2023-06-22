using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public GameController gameController;
    float currentTime = 0f;
    float startingTime = 15f;
    public GameObject uiObject;
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
        currentTime = startingTime;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.selfDestruct == true) {
            uiObject.SetActive(true);
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0) {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
