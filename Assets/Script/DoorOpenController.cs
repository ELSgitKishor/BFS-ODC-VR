using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenController : MonoBehaviour
{
    public GameObject door,door1,door2, door_cabin_exit, Cabin_anim_7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cabin_DoorAnim")
        {
            door.GetComponent<Animator>().SetInteger("Open", 1); 

        }
        if (other.gameObject.name == "cabin_animate_door_1")
        {
            
            door1.GetComponent<Animator>().SetInteger("Open", 1);

        }
        if (other.gameObject.name == "new_cabin_animate")
        {

            door2.GetComponent<Animator>().SetInteger("Open", 1);

        }
         if (other.gameObject.name == "new_cabin_animate")
        {

            door2.GetComponent<Animator>().SetInteger("Open", 1);

        }
        if (other.gameObject.name == "Cabin_anim_7")
        {
            Cabin_anim_7.GetComponent<Animator>().SetInteger("Open", 1);
        }

    }
}
