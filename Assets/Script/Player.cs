using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    /*Required for player movement------------------------*/
    /*For windows*/
    float rootSpeed = 80;
    float rot = 0f;
    float gravity = 10;
    Vector3 moveDir = Vector3.zero;
    CharacterController characterController;
    public float speed = 5;
    /*Required for player movement - END*/

    public VideoPlayer videoPlayer; /*Video player*/

    public AudioSource audioSource; /*Audio player*/

    /*Number of audios is equal to number of OSTs*/
    public AudioClip reception, reception1, reception2, lobby, conference, workspace, brainstorm, mtroom, managerscubicle, pantry, hangout, locker;
    public GameObject introScreen, BottomBand, OST_reception, OST_reception1, OST_reception2, OST_lobby, OST_conference, OST_workspace, OST_brainstorm, OST_mtroom, OST_managerscubicle, OST_pantry, OST_hangout, OST_locker;
    public static bool ost_status = false; /*Wheather OST is on or not*/
    public static Coroutine OST_coroutine = null;

    public GameObject conferenceRoomText, vcRoomText, workspaceText, cafetetriaText, lockerRoomText, brainstromtext;

    public static bool MiniMap_status = false;
    public GameObject MiniMap, MiniMap_minimize; /*For live map*/
 //   public GameObject MiniMap_minimize; /*For live map MiniMap*/
    public Camera miniMapCamera, mainCamera;
    private int headMoveCount = 0;
    private float cameraSizeMin = 30.0f, cameraSizeMax = 92.0f, cameraSizeMid = 55.0f;
    Animator animator;  /*For handling the map animations*/
    public GameObject arrow;
    public GameObject ExitScreen, completeScreen, bottom_panel;
    private GameObject[] allHit;
    public bool helpUI, mapui;
    public GameObject helpScreen, helpScreen1;
     
    void Start()
    {
        // playTheVideo(false);   /*Pausing the video on load*/

        // MiniMap_status = false;
        // miniMapCamera.orthographicSize = cameraSizeMin;  
        //   rot = 90f;

        //IntroScreen_status = false;
        //helpScreenStatus = true;
          helpScreen.SetActive(true);
        //  OST_reception.SetActive(true);

        // closeHelp(false);
        // close_introScreen();

        playTheVideo(false);   /*Pausing the video on load*/
        characterController = GetComponent<CharacterController>();
        MiniMap_status = false;
        miniMapCamera.orthographicSize = cameraSizeMin;
       // rot = 90f;
    }

    public static bool IntroScreen_status = false;
    public static bool helpScreenStatus = true;  /*For help screen*/
    public void closeHelp(bool helpbtnstatus)
    {


        if (helpbtnstatus == true)
        {

            // help_close1.SetActive(false);
            helpScreen.SetActive(false);
            introScreen.SetActive(true);

        }
        else
        {
            introScreen.SetActive(false);
            // help_close1.SetActive(true);
            helpScreen.SetActive(true);

        }
    }
    public void close_introScreen(bool onoff)
    {
        if (onoff == true)
        {
            BottomBand.SetActive(true);
            introScreen.SetActive(false);
            OST_reception.SetActive(true);
            audioSource.clip = reception;
            audioSource.Play();
            Invoke("CloseWelcomeScreen", audioSource.clip.length);


        }
    }
    public void CloseWelcomeScreen()
    {
        BottomBand.SetActive(false);
        introScreen.SetActive(false);
        OST_reception.SetActive(false);
        hideAllOST();
    }
    /* Update is called once per frame---------------------------------------*/
    public bool onoff, welcomeUI;

    void Update()
    {

        if (onoff == true)
        {
            closeHelp(true);
            onoff = false;
        }
        if (welcomeUI == true)
        {
            close_introScreen(true);
            welcomeUI = false;
        }
        /*Player movement ---------------------------------*/

        if (OVRInput.GetDown(OVRInput.Button.One))
        {//&& !CameraScript.helpScreenStatus && !CameraScript.IntroScreen_status){
            /*Hiding the maximize map and showing the minimize map*/
            if (!mapui)
            {
                mapui = true;
                MiniMap_minimize.SetActive(false);
                //miniMapCamera.orthographicSize = cameraSizeMid;

            }
            else
            {
                mapui = false;
                //  miniMapCamera.orthographicSize = cameraSizeMin;
                MiniMap_minimize.SetActive(true);
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {

            if (!helpUI)
            {
                helpUI = true;
                helpScreen1.SetActive(false);
            }
            else
            {
                helpUI = false;
                helpScreen1.SetActive(true);
            }
        }
 
    }

    /*Firing the specific event when the player colliding with invisible hit area--------------------------------------------*/
    private void OnTriggerEnter(Collider other) {
        
        string collider_name = other.gameObject.name;
        //console_text.text = "Coolided with " + other.gameObject.name;

        if(collider_name.Trim().ToLower() != "_vc_room_exit"){
            //other.gameObject.SetActive(false);
           //GameObject.Find(other.gameObject.name).SetActive(false);
        }
        if(OST_coroutine != null){
            StopCoroutine(OST_coroutine);
        }
       
        switch (collider_name.Trim().ToLower())
        { 
            case "_vc_room_enter":                    
                playTheVideo(true); 
                vcRoomText.SetActive(true);
               // Invoke("hideAllOST", audioSource.clip.length);
                break;   
            case "_vc_room_exit":   
                
                playTheVideo(false);
                
                break;      
            case "reception1":     /*Exit door*/
                showOST(OST_reception1, 5);                
                audioSource.clip = reception1;
                audioSource.Play();
                Invoke("hideAllOST", reception1.length);

                break;   
            case "reception2":      /*Access door*/
                showOST(OST_reception2, 10);          
                audioSource.clip = reception2;
                audioSource.Play();   
				arrow.SetActive(false);
                Invoke("hideAllOST", reception2.length);
                break;   
            case "lobby":      /*lobby*/                
                showOST(OST_lobby, 10);          
                audioSource.clip = lobby;
                audioSource.Play();
                Invoke("hideAllOST", lobby.length);
                break;
            case "conference":      /*conference room*/
                showOST(OST_conference, 10);          
                audioSource.clip = conference;
                audioSource.Play();
                
                conferenceRoomText.SetActive(true);
              Invoke("hideAllOST", conference.length);
                break; 
            case "workspace":      /*workspace*/
                showOST(OST_workspace, 10);          
                audioSource.clip = workspace;
                audioSource.Play();
                
                workspaceText.SetActive(true);
                Invoke("hideAllOST", workspace.length);
                break; 
            case "brainstorm":      /*brainstorm area*/
                showOST(OST_brainstorm, 10);          
                audioSource.clip = brainstorm;
                audioSource.Play(); 
                brainstromtext.SetActive(true);
                Invoke("hideAllOST", brainstorm.length);
                break; 
            case "mtroom":      /*mtroom beside brain strom*/
                showOST(OST_mtroom, 19);          
                audioSource.clip = mtroom;
                audioSource.Play(); 
                break; 
            case "managerscubicle":      /*managers cubicle*/
                showOST(OST_managerscubicle, 10);          
                audioSource.clip = managerscubicle;
                audioSource.Play(); 
                break; 
            case "pantry":      /*pantry*/
                showOST(OST_pantry, 10);          
                audioSource.clip = pantry;
                audioSource.Play(); 
                cafetetriaText.SetActive(true);
                 Invoke("hideAllOST", pantry.length);

                break; 
            case "hangout":      /*hangout area*/
                showOST(OST_hangout, 10);          
                audioSource.clip = hangout;
                audioSource.Play(); 
                break; 
            case "locker":      /*locker room*/
                showOST(OST_locker, 15);          
                audioSource.clip = locker;
                audioSource.Play(); 
                lockerRoomText.SetActive(true);
                Invoke("hideAllOST", locker.length);
                break;              
            default:
                //some code 
                break;
        }
       // Invoke("hideAllOST", audioSource.clip.length);
        // GameObject.Find(other.gameObject.name).SetActive(false);
    }
    /*Firing the specific event when the player colliding with invisible hit area - END*/

    /*Playing the VC room video------------------------------------------------------*/
    void playTheVideo(bool playStatus){
        StartCoroutine(playVideo(playStatus));
    }
    
    IEnumerator playVideo(bool playStatus) {          

        videoPlayer.Prepare();        
        WaitForSeconds waitForSeconds = new WaitForSeconds(1); 

        while(!videoPlayer.isPrepared){
            yield return waitForSeconds; 
            break;
        }

        if(playStatus){
            videoPlayer.Play();
        }else{
            videoPlayer.Pause();
        }
        
    }
    /*Playing the VC room video - END*/

    /*Hiding all the OSTs-----------------------------------------------------------*/
    void hideAllOST(){
        BottomBand.SetActive(false);
        OST_reception.SetActive(false);
        OST_reception1.SetActive(false);
        OST_reception2.SetActive(false);
        OST_lobby.SetActive(false);
        OST_conference.SetActive(false);
        OST_workspace.SetActive(false);
        OST_brainstorm.SetActive(false);
        OST_mtroom.SetActive(false);
        OST_managerscubicle.SetActive(false);
        OST_pantry.SetActive(false);
        OST_hangout.SetActive(false);
        OST_locker.SetActive(false);
        audioSource.Pause();
        ost_status = false;
        bottom_panel.SetActive(false);
        BottomBand.SetActive(false);
    }
    /*Hiding all the OSTs - END*/

    /*Hiding the OST afte some time-------------------------------------------------*/
    IEnumerator hideTheOSTPopUp(GameObject OST_popup, int hideTime) {       
        yield return new WaitForSeconds(hideTime); 
        OST_popup.SetActive(false);            
        ost_status = false;    
        
        /*Checking all the Hits*/
        allHit = GameObject.FindGameObjectsWithTag("HitObject");
        int hitObjectStatusCounter = 0;
        for (int i = 0; i < allHit.Length; i++)
        {
            hitObjectStatusCounter ++;
        }

        if (hitObjectStatusCounter <=0)
        {
            Debug.Log("No hit found");
            bottom_panel.SetActive(true);
            completeScreen.SetActive(true);
        }else{
            Debug.Log("hit true");
        }
        
    }
    /*Hiding the OST afte some time - ENS*/

    /*Showing a particular OST and hiding others------------------------------------*/
    void showOST(GameObject OST_popup, int hideTime){
        hideAllOST();
        OST_popup.SetActive(true);    
        bottom_panel.SetActive(true);
        OST_coroutine = StartCoroutine(hideTheOSTPopUp(OST_popup, hideTime));
        ost_status = true;
    }
    /*Showing a particular OST and hiding others - END*/

}
