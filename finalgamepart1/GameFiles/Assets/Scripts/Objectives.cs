using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    public GameObject uiObject;
    public GameController gameController;
    Text uiObjectText;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(true);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        uiObjectText = uiObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.keyCards == 2 && gameController.selfDestruct == false)
        {
            uiObjectText.text = "Get to the launch room and initiate self destruction";
        }

        if (gameController.selfDestruct == true)
        {
            uiObjectText.text = "Escape the station before it blows up!";
        }

        
    }
}
