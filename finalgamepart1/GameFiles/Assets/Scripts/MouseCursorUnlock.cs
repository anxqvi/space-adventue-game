using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorUnlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.None;//This will unlock the cursor where its to be needed
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
