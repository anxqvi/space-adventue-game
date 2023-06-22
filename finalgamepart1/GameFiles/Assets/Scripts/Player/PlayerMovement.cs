using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;//A reference to the character controller
    public float speed=10f;//a speed variable to control the speed of the player
    private Vector3 move;//use to move the player in a direction
    public float gravity=-10f;//to control the gravity by this variable
    public float jumpHeight=2f;//To control the jump force on the player
    private Vector3 velocity;//to apply the velocity

    public Transform groundCheck;//to check either the player is grounded or not
    public LayerMask groundLayer;//to check the ground layer
    private bool isGrounded;//to check the player is ground true or false
    public Animator animator;
    InputAction movement;//use to move the player for certain actions such as reload etc
    InputAction jump;// use for jumping 
    // Start is called before the first frame update
    //Health System
    public float Health=10f;
    public float HealthDamage=10f;
    public Slider HealthBar;
    
    void Start()
    {
        jump=new InputAction("Jump",binding:"<Keyboard>/space");
        jump.AddBinding("<Gamepad>/a");

        movement=new InputAction("PlayerMovement",binding:"<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
        .With("Up","<Keyboard>/w")
        .With("Up","<Keyboard>/upArrow")
          .With("Down","<Keyboard>/s")
          .With("Up","<Keyboard>/downArrow")
            .With("Left","<Keyboard>/a")
            .With("Up","<Keyboard>/leftArrow")
              .With("Right","<Keyboard>/d")
              .With("Up","<Keyboard>/rightArrow");
    
             movement.Enable();
             jump.Enable();
             //Health 
             HealthBar.value=Health;
             Debug.Log("Health Scripts");
    }

    // Update is called once per frame
    void Update()
    {
      
        float x=movement.ReadValue<Vector2>().x;
        float z=movement.ReadValue<Vector2>().y;
        animator.SetFloat("speed",Mathf.Abs(x)+Mathf.Abs(z));
        move =transform.right*x+transform.forward *z;// to initialize the axis x and y
        
        controller.Move(move*speed*Time.deltaTime);//we can move the player using the character controller 
    
        isGrounded=Physics.CheckSphere(groundCheck.position,0.3f,groundLayer);// a builtin function which creates a sphere to which interact with the ground 
         
         if(isGrounded && velocity.y<0)
         {
                 velocity.y=-1f;
         }
         //To Jump

         if(isGrounded)// if isgrounded is true then if we hit the jump button the player jump
        {
            if(Mathf.Approximately(jump.ReadValue<float>(),1))
            {
                Jump();//to call the jump function
            }
        }
        else
        {
             velocity.y+=gravity*Time.deltaTime;// to add the gravity to our player
        }
       
        controller.Move(velocity*Time.deltaTime);
    
    }
    //Jump Mehtod

    private void Jump()
    {
        velocity.y=Mathf.Sqrt(jumpHeight*2*-gravity);// we need to change the velocity value in y direction
    }
    //Health Method 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer.Equals(6))
        {
            Debug.Log("Health Decreases");
              Health-=HealthDamage;
               HealthBar.value=Health;
             
        }
          if(Health<=0)
               {
               SceneManager.LoadScene("GameOver");
               }
    }
}
