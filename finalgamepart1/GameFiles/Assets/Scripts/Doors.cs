using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour

{
    public Animator door;
    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        door = this.transform.parent.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            DoorOpens();
        }
    }

    void DoorOpens()
    {
        door.SetBool("character_nearby", true);
    }

}
