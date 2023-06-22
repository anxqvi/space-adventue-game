using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3SelfDestruct : MonoBehaviour
{
    public GameController gameController;
    public GameObject uiObject;
    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        uiObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            uiObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            uiObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            activateSelfDestruct();
        }
    }

    void activateSelfDestruct()
    {
        gameController.selfDestruct = true;
        Destroy(transform.gameObject);
        Destroy(uiObject);
    }

}
