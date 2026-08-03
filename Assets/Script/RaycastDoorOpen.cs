using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDoorOpen : MonoBehaviour
{
    Camera cam;
    public GameObject odc_entry_gate_from_rcp;
    public GameObject first_room_door;
    public GameObject second_room_door;
    public GameObject third_room_door;
    public GameObject left_corner_mt_room_door;
    public GameObject Middle_cabin_animate_door;

    public GameObject pantry_door;
    // public GameObject locker_room_door;
    /* All the door which have animations - END */

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        print(cam.name);
    }

    // Update is called once per frame
    void Update()
    {
        //DrawRay 
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 100f;
        mousepos = cam.ScreenToWorldPoint(mousepos);
        Debug.DrawRay(transform.position, mousepos - transform.position, Color.black);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100))
            {
                Debug.Log("Obj Name = " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.name == "ODC_Entry_Gate_reception_Swipe_mechine")
                {
                    Debug.Log("ODC_Entry  = " + hit.transform.gameObject.name);
                    //door 1
                    odc_entry_gate_from_rcp.GetComponent<Animator>().SetInteger("Open", 1);

                }
                if (hit.transform.gameObject.name.Trim().ToLower() == "ODC_Entry_Gate_reception_Swipe_mechine_1")
                {
                    //door 1
                    odc_entry_gate_from_rcp.GetComponent<Animator>().SetInteger("Open", 1);

                }
                if (hit.transform.gameObject.name.Trim().ToLower() == "first_room_door_animate")
                {
                    //door 2
                    first_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                }
                if (hit.transform.gameObject.name.Trim().ToLower() == "second_room_door")
                {
                    //door 3
                    second_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                }
                if (hit.transform.gameObject.name.Trim().ToLower() == "Third_WorkSpace_Swipe_mechine")
                {
                    //door 4
                    third_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                }
                if (hit.transform.gameObject.name.Trim().ToLower() == "Left_corner_mt_room_door")
                {
                    //door 5
                    left_corner_mt_room_door.GetComponent<Animator>().SetInteger("Open", 1);


                }
                if (hit.transform.gameObject.name.Trim().ToLower() == "Middle_cabin_animate_door")
                {
                    //door 6
                    Middle_cabin_animate_door.GetComponent<Animator>().SetInteger("Open", 1);


                }
                if (hit.transform.gameObject.name.Trim().ToLower() == "Cafeteria_Swipe_mechine_C")
                {
                    //door 7
                    pantry_door.GetComponent<Animator>().SetInteger("Open", 1);


                }
                if (hit.transform.gameObject.name.Trim().ToLower() == "Cafeteria_Swipe_mechine_C_1")
                {
                    //door 7
                    pantry_door.GetComponent<Animator>().SetInteger("Open", 1);



                }
            }
        }
    }
}
