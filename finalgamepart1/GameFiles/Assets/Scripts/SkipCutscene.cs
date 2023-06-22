using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    public float changeTime;

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            SceneManager.LoadScene("Level1");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
