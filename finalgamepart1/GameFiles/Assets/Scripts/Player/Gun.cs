using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour
{
  
  public Transform fpsCam;//camera variable
  public float range=20f;//variable for specific range
  public float impactForce=150f;//force applied on objects by gun shooting
  public int fireRate=10;//to limit the fire rate
  InputAction shoot;//To initialize an input system
  public int damageAmount=20;
  private float nextTimetoFire=0;
  //Muzzle Flash
  public ParticleSystem muzzleFlash;//muzzleFlash variable
  public GameObject impactEffect;
  //Shoot Animations
  public Animator animator;
    
    
    void Start()
    {
        shoot =new InputAction("Shoot",binding:"<mouse>/leftButton");// to shoot with pressing the left mouse button
        shoot.AddBinding("<Gamepad>/x");//to shoot by pressing the x button on the game pad
        
        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        bool isShooting=shoot.ReadValue<float>()==1;//variable to check either shoot or not
       animator.SetBool("isShooting",isShooting);
       if(isShooting && Time.time>=nextTimetoFire)//to check if isshooting is true then perform the shooting task
       {
         
         nextTimetoFire=Time.time+1f/fireRate;
         Fire();//this will call the fire method
       }
    }

///Raycasting
    private void Fire()
    {
      AudioManager.instance.Play("Shoot");//to play the shoot sound on click
      RaycastHit hit;//Raycast Variable
      muzzleFlash.Play();//to play the muzzle flash on fire shoot
          if(Physics.Raycast(fpsCam.position,fpsCam.forward,out hit,range))
          {
            if(hit.rigidbody !=null)
            {
              hit.rigidbody.AddForce(-hit.normal*impactForce);
            }
            Enemy e=hit.transform.GetComponent<Enemy>();
            if(e!=null)
            {
              e.TakeDamage(damageAmount);
              return;
            }
            Quaternion impactRotation =Quaternion.LookRotation(hit.normal);//to create rotation based on normal vector
            GameObject impact =  Instantiate(impactEffect,hit.point,impactRotation);
            impact.transform.parent=hit.transform;
            Destroy(impact,5);
          }
    }
}
