using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CameraScript : MonoBehaviour
{
    public Camera cam;
    // public Material mat1, mat2, mat3_card,mat4_glass; /*Door material, normal and hover */
    public RaycastHit hitObj;

    bool inGame = false; /* True means the controller line renderer has collided with a door*/
    string hitname; /* Storing the collided gameobject's name*/

    /*All the door which have animations*/
    public GameObject odc_entry_gate_from_rcp;
    public GameObject first_room_door;
    public GameObject second_room_door;
    public GameObject third_room_door;
    public GameObject left_corner_mt_room_door;
    public GameObject Middle_cabin_animate_door;
     
    public GameObject pantry_door;
    public GameObject Door_8;
   // public GameObject locker_room_door;
    /* All the door which have animations - END */

    public GameObject door_alert;

   // public GameObject vc_room_exit_hit;

    public GameObject MiniMap,MiniMap_minimize; /*For live map*/    
    
    public GameObject IntroScreen; /* Intro popup*/
    
    public static bool IntroScreen_status = false; /*For checking the map and intro screen status, wheather it is visible or not*/

    public GameObject OST_reception; /*Welcome OST*/
    public AudioClip reception; /*Welcome audio*/
    public AudioSource audioSource; /**/

    //Coroutine OST_coroutine = null;

    public static bool helpScreenStatus = true;  /*For help screen*/
    public GameObject helpScreen, helpScreen1;
    public GameObject ExitScreen;
    public GameObject bottom_panel, help_btn, help_close1;
    Animator animator;  /*For handling the door animations*/
    Animator access_beep_animator,access_beep_animator1;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;
        Player.ost_status = false;
        IntroScreen_status = false;
        helpScreenStatus = true;
        helpScreen.SetActive(true);
        bottom_panel.SetActive(false);
        //access_beep_animator = access_beep.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {  //DrawRay 
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 100f;
        mousepos = cam.ScreenToWorldPoint(mousepos);
        Debug.DrawRay(transform.position, mousepos - transform.position, Color.black);
        //RaycastHit hit;

        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit)) {
        //    Vector3 forward =  transform.TransformDirection(Vector3.forward) * 10;
        //    Debug.DrawRay(transform.position, forward, Color.green);
        //    Transform objectHit = hit.transform;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
                if (hit.collider != null && hit.transform.CompareTag("Gate"))
            {
                
                string hitname_copy = hit.transform.gameObject.name;
                // Do something with the object that was hit by the raycast.
                hitObj = hit;                     
              //  hitObj.collider.gameObject.GetComponent<Renderer>().material = mat2;   
                door_alert.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Obj Name = " + hit.transform.gameObject.name);
                    if (hit.transform.gameObject.name == "ODC_Entry_Gate_reception_Swipe_mechine")
                    {
                        //door 1
                        odc_entry_gate_from_rcp.GetComponent<Animator>().SetInteger("Open", 1);

                    }
                     if(hit.transform.gameObject.name == "ODC_Entry_Gate_reception_Swipe_mechine_1")
                    {
                        //door 1
                        odc_entry_gate_from_rcp.GetComponent<Animator>().SetInteger("Open", 1);

                    }
                     if(hit.transform.gameObject.name == "first_room_door_animate")
                    {
                        //door 2
                        first_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                    }
                     if(hit.transform.gameObject.name == "second_room_door")
                    {
                        //door 3
                        second_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                    }
                     if(hit.transform.gameObject.name == "Third_WorkSpace_Swipe_mechine")
                    {
                        //door 4
                        third_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                    }  if(hit.transform.gameObject.name == "Swipe_mechine_W")
                    {
                        //door 4
                        third_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                    }
                     if(hit.transform.gameObject.name == "Left_corner_mt_room_door")
                    {
                        //door 5
                        left_corner_mt_room_door.GetComponent<Animator>().SetInteger("Open", 1);


                    }
                    if (hit.transform.gameObject.name == "Middle_cabin_animate_door")
                    {
                        //door 6
                        Middle_cabin_animate_door.GetComponent<Animator>().SetInteger("Open", 1);


                    }
                     if (hit.transform.gameObject.name == "Cafeteria_Swipe_mechine_C")
                    {
                        //door 7
                        pantry_door.GetComponent<Animator>().SetInteger("Open", 1);


                    }
                    if (hit.transform.gameObject.name == "Cafeteria_Swipe_mechine_C_1")
                    {
                        //door 7
                        pantry_door.GetComponent<Animator>().SetInteger("Open", 1);

                    }
                    if (hit.transform.gameObject.name == "Door_8")
                    {
                      //door 8
                      Door_8.GetComponent<Animator>().SetInteger("Open", 1);

                    }

                }
            }
                
        }

        //if(inGame){                
        //    setGameType(hitname);
        //    inGame = false;
        //} 
       
    }

    public void CloseDoors()
    {
        odc_entry_gate_from_rcp.GetComponent<Animator>().SetInteger("Open", 2);
        first_room_door.GetComponent<Animator>().SetInteger("Open", 2);
        second_room_door.GetComponent<Animator>().SetInteger("Open", 2);
        third_room_door.GetComponent<Animator>().SetInteger("Open", 2);
        left_corner_mt_room_door.GetComponent<Animator>().SetInteger("Open", 2);
        Middle_cabin_animate_door.GetComponent<Animator>().SetInteger("Open", 2);
        pantry_door.GetComponent<Animator>().SetInteger("Open", 2);
        Door_8.GetComponent<Animator>().SetInteger("Open", 2);
    }

    /*Playing the animation depending on the name.*/
    void setGameType(string gameType){
         
        switch (gameType.Trim().ToLower())
        { 
            case "ODC_Entry_Gate_reception_Swipe_mechine":
                //door 1
                odc_entry_gate_from_rcp.GetComponent<Animator>().SetInteger("Open", 1);
                 
                break; 
            case "ODC_Entry_Gate_reception_Swipe_mechine_1":
                odc_entry_gate_from_rcp.GetComponent<Animator>().SetInteger("Open", 1);
                 
                break;
            case "first_room_door_animate":
                //door 2
                first_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                break;
             
            case "second_room_door":
                //door 3
                second_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                break;
            case "Third_WorkSpace_Swipe_mechine":
                //door 4
                third_room_door.GetComponent<Animator>().SetInteger("Open", 1);
                break;
                   
            case "Left_corner_mt_room_door":
                //door 5
                left_corner_mt_room_door.GetComponent<Animator>().SetInteger("Open", 1);

                break;   

            case "Middle_cabin_animate_door":
                //door 6
                Middle_cabin_animate_door.GetComponent<Animator>().SetInteger("Open", 1);

                break;  
            case "Cafeteria_Swipe_mechine_C":
                //door 7
                pantry_door.GetComponent<Animator>().SetInteger("Open", 1);

                break;
            case "Cafeteria_Swipe_mechine_C_1":
                pantry_door.GetComponent<Animator>().SetInteger("Open", 1);

                break;   
            default:
                //some code 
                break;
        }
                       
        
        
    }
     

    /*Hiding the OST afte some time*/
    IEnumerator hideTheOSTPopUp(GameObject OST_popup) {       
        yield return new WaitForSeconds(10); 
        OST_popup.SetActive(false);    
        Player.ost_status = false;    
        StopCoroutine(Player.OST_coroutine);
    }
    /*Hiding the OST afte some time - ENS*/

    /*Closing help popup*/
    public void closeHelp(bool helpbtnstatus){
       
        if(helpScreenStatus){
            helpScreenStatus = false;
            helpScreen.SetActive(false);
            if(!helpbtnstatus){
                IntroScreen_status = true;
                IntroScreen.SetActive(true); 
                help_close1.SetActive(false);
            }             
        }else{
            helpScreenStatus = true;
            helpScreen.SetActive(true);
        }    
    }
    public void closeHelp2(bool helpbtnstatus)
    {

        if (helpScreenStatus)
        {
            helpScreenStatus = false;
            helpScreen1.SetActive(false);
            if (!helpbtnstatus)
            {
                IntroScreen_status = true;
                IntroScreen.SetActive(true);
                helpScreen1.SetActive(false);
            }
        }
        else
        {
            helpScreenStatus = true;
            helpScreen1.SetActive(true);
        }
    }
    /*Closing the Intro*/
    public void closeIntro(){
        if(IntroScreen_status){                  
            IntroScreen.SetActive(false);  
            IntroScreen_status = false;
            /*Showing the OST*/
            OST_reception.SetActive(true);
            audioSource.clip = reception;
            audioSource.Play(); 
            Player.ost_status = true;
            Player.OST_coroutine = StartCoroutine(hideTheOSTPopUp(OST_reception));
            /*Showing the mnimize map*/
            MiniMap_minimize.SetActive(true);     
            bottom_panel.SetActive(true);     
            help_btn.SetActive(true);
        }
    }

    public void exitGame(bool exitStatus){
        if(exitStatus){   
            Application.Quit();
        }else{
            ExitScreen.SetActive(false);
        }
    }
}
