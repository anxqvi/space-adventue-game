using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
   

    public float mouseSensitivity=100f;//variable to control the mouse sensitivity
    public Transform playerBody;//a reference variabel for player body to control the player body
    
    float xRotation;//rotate the camera in x rotation 
    
    // Start is called before the first frame update
    void Start()
    {
         Cursor.lockState=CursorLockMode.Locked;//To hide the mouse cursor in gameplay
    }

    // Update is called once per frame
    void Update()
    {
    float mouseX=0;//Variable for mouse horizontal value
    float mouseY=0;//Variable for mouse vertical value
    if(Mouse.current!=null )//to check which type mouse is plugin
    {
        mouseX=Mouse.current.delta.ReadValue().x*mouseSensitivity;//To access the mouse x value
        mouseY=Mouse.current.delta.ReadValue().y*mouseSensitivity;//To access the mouse y value
    }
        if(Gamepad.current!=null )//For gamePade
    {
        mouseX=Gamepad.current.rightStick.ReadValue().x;//To access the mouse x value
        mouseY=Gamepad.current.rightStick.ReadValue().y;//To access the mouse y value
    }
        //float mouseX=Input.GetAxis("Mouse X")*mouseSensitivity;
       // float mouseY=Input.GetAxis("Mouse Y")*mouseSensitivity;
        xRotation -=mouseY*Time.deltaTime;// to rotate the camera in y direction without rotating the player body
        xRotation=Mathf.Clamp(xRotation,-80,80);//to limit the y mouse rotation between specific values
        
        
        transform.localRotation= Quaternion.Euler(xRotation,0,0);//Rotate the camera with mouse in y direction with certain amgle
       
        playerBody.Rotate(Vector3.up*mouseX*Time.deltaTime);// to rotate the player body in x axis direction
    }
}
