using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;

public class Player_windows : MonoBehaviour
{
    public GameObject playerPos;
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

    /*Number of audios is equal to number of OSTs*///OST_reception
    public AudioClip reception, reception1, reception2, lobby, conference, workspace, brainstorm, mtroom, managerscubicle, pantry, hangout, locker;
    public GameObject   OST_reception1, OST_reception2, OST_lobby, OST_conference, OST_workspace, OST_brainstorm, OST_mtroom, OST_managerscubicle, OST_pantry, OST_hangout, OST_locker;
    public static bool ost_status = false; /*Wheather OST is on or not*/
    public static Coroutine OST_coroutine = null;

    public GameObject conferenceRoomText, vcRoomText, workspaceText, cafetetriaText, lockerRoomText, brainstromtext;

    public static bool MiniMap_status = false;
    public GameObject MiniMap, MiniMap_minimize; /*For live map*/
    public Camera miniMapCamera, mainCamera;
    private int headMoveCount = 0;
    public float cameraSizeMin = 30.0f, cameraSizeMax = 92.0f, cameraSizeMid = 55.0f;
    Animator animator;  /*For handling the map animations*/
    public GameObject arrow;
    public GameObject ExitScreen, completeScreen, bottom_panel;
    private GameObject[] allHit;
    private void Awake()
    {
        this.gameObject.transform.position =new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, playerPos.transform.position.z);
    }
    void Start()
    {
        this.gameObject.transform.position = playerPos.transform.position;
        playTheVideo(false);   /*Pausing the video on load*/
        characterController = GetComponent<CharacterController>();
        MiniMap_status = false;
        miniMapCamera.orthographicSize = cameraSizeMin;
       // rot = 90f;
    }
    public void Close_help()
    {

    }
    public void Close_intro()
    {

    }
    public void Close_Welcome()
    {

    }
    /* Update is called once per frame---------------------------------------*/
    bool on = true;
    void Update()
    {
        if (on == true)
        {
            moveDir = new Vector3(0, 0, 1); // for moving the character
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
            this.gameObject.transform.position = playerPos.transform.position;
            on = false;
        }

        /*Player movement ---------------------------------*/

        /*if(OVRInput.Get(OVRInput.Touch.PrimaryTouchpad) && !ControllerScript.MiniMap_status && !ControllerScript.IntroScreen_status && !ost_status){*/     /*Required if you want to force player wait until ost disappear*/
        if (Input.GetKey(KeyCode.S)||Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.W )|| Input.GetKey(KeyCode.W)||(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) && !MiniMap_status && !CameraScript.IntroScreen_status)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDir = new Vector3(0, 0, 1); // for moving the character
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);  // for moving to the rotated direction
            }
            if (Input.GetKey(KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 1); // for moving the character
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);  // for moving to the rotated direction
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                moveDir = new Vector3(0, 0, 0); // for stop moving the character
            } if (Input.GetKeyUp(KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 0); // for stop moving the character
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDir = new Vector3(0, 0, -1); // for moving the character
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);  // for moving to the rotated direction
            }if (Input.GetKey(KeyCode.S))
            {
                moveDir = new Vector3(0, 0, -1); // for moving the character
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);  // for moving to the rotated direction
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                moveDir = new Vector3(0, 0, 0); // for stop moving the character
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                moveDir = new Vector3(0, 0, 0); // for stop moving the character
            }

            moveDir.y -= gravity * Time.deltaTime;
            characterController.Move(moveDir * Time.deltaTime); // moving the character           

        }
        else
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
        }
        rot += Input.GetAxis("Horizontal") * rootSpeed * Time.deltaTime;  // defining the rotation, while pressing A or D or left right arrow
        transform.eulerAngles = new Vector3(0, rot, 0); // rotating the view   
        /*Player movement - END*/

        if (Input.GetKeyUp(KeyCode.M) && !CameraScript.helpScreenStatus && !CameraScript.IntroScreen_status)
        {
            /*Hiding the maximize map and showing the minimize map*/
            if (!MiniMap_status)
            {
                MiniMap_status = true;
                MiniMap_minimize.SetActive(false);
                miniMapCamera.orthographicSize = cameraSizeMid;
                MiniMap.SetActive(true);
            }
            else
            {
                MiniMap_status = false;
                MiniMap.SetActive(false);
                miniMapCamera.orthographicSize = cameraSizeMin;
                MiniMap_minimize.SetActive(true);
                /*animator = MiniMap_minimize.GetComponent<Animator>();
                animator.SetInteger("mapBlink", 0);*/
            }
        }


        if (MiniMap_status)
        {
            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0f)
            {
                // scroll up                
                if (cameraSizeMin < miniMapCamera.orthographicSize)
                {
                    miniMapCamera.orthographicSize = miniMapCamera.orthographicSize - 10;
                }
            }
            else if (d < 0f)
            {
                // scroll down               
                if (cameraSizeMax >= miniMapCamera.orthographicSize)
                {
                    miniMapCamera.orthographicSize = miniMapCamera.orthographicSize + 10;
                }
            }
        }

        if (!MiniMap_status && !CameraScript.helpScreenStatus)
        {
            var d = Input.GetAxis("Mouse ScrollWheel");
            Vector3 rotation = mainCamera.transform.eulerAngles;
            if (d > 0f)
            {
                if (headMoveCount > -2)
                {
                    rotation.x -= 10;
                    headMoveCount -= 1;
                }
            }
            else if (d < 0f)
            {
                if (headMoveCount < 2)
                {
                    rotation.x += 10;
                    headMoveCount += 1;
                }
            }
            mainCamera.transform.eulerAngles = rotation;
        }

        if (Input.GetKeyUp(KeyCode.C) )
        {
            //  Player.ost_status = false;
            CloseAllUI();
        }

        /*Showing the exit popup*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitScreen.SetActive(true);
        }

        /* Hiding all the OST popup and pausing the audio*/
        if (!ost_status)
        {
            //console_text.text = "OST STATUS = "+ost_status;     
            hideAllOST();
            //StopCoroutine(OST_coroutine);
        }

    }
    public CameraScript cam;
    /*Firing the specific event when the player colliding with invisible hit area--------------------------------------------*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Close")
        {
            cam.CloseDoors();
        }
        string collider_name = other.gameObject.name;
        //console_text.text = "Coolided with " + other.gameObject.name;

        if (collider_name.Trim().ToLower() != "_vc_room_exit")
        {
            //other.gameObject.SetActive(false);
           // GameObject.Find(other.gameObject.name).SetActive(false);
        }
        if (OST_coroutine != null)
        {
            StopCoroutine(OST_coroutine);
        }

        switch (collider_name.Trim().ToLower())
        {
            case "_vc_room_enter":
                playTheVideo(true);
                vcRoomText.SetActive(true);
                break;
            case "_vc_room_exit":
                playTheVideo(false);
                break;
            case "reception1":     /*Exit door*/
                showOST(OST_reception1, 5);
                audioSource.clip = reception1;
                audioSource.Play();
                break;
            case "reception2":      /*Access door*/
                showOST(OST_reception2, 10);
                audioSource.clip = reception2;
                audioSource.Play();
                arrow.SetActive(false);
                break;
            case "lobby":      /*lobby*/
                showOST(OST_lobby, 10);
                audioSource.clip = lobby;
                audioSource.Play();
                break;
            case "conference":      /*conference room*/
                showOST(OST_conference, 10);
                audioSource.clip = conference;
                audioSource.Play();
                conferenceRoomText.SetActive(true);
                break;
            case "workspace":      /*workspace*/
                showOST(OST_workspace, 10);
                audioSource.clip = workspace;
                audioSource.Play();
                workspaceText.SetActive(true);
                break;
            case "brainstorm":      /*brainstorm area*/
                showOST(OST_brainstorm, 10);
                audioSource.clip = brainstorm;
                audioSource.Play();
                brainstromtext.SetActive(true);
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
                break;
            default:
                //some code 
                break;
        }
         
    }
    /*Firing the specific event when the player colliding with invisible hit area - END*/

    /*Playing the VC room video------------------------------------------------------*/
    void playTheVideo(bool playStatus)
    {
        StartCoroutine(playVideo(playStatus));
    }

    IEnumerator playVideo(bool playStatus)
    {

        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        if (playStatus)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
        }

    }
    /*Playing the VC room video - END*/

    /*Hiding all the OSTs-----------------------------------------------------------*/
    void hideAllOST()
    {
      //  OST_reception.SetActive(false);
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
        ost_status = false;
        bottom_panel.SetActive(false);
    }

    public void CloseAllUI()
    {
        
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
        bottom_panel.SetActive(false);
    }
    /*Hiding all the OSTs - END*/

    /*Hiding the OST afte some time-------------------------------------------------*/
    IEnumerator hideTheOSTPopUp(GameObject OST_popup, int hideTime)
    {
        yield return new WaitForSeconds(hideTime);
        OST_popup.SetActive(false);
        ost_status = false;

        /*Checking all the Hits*/
        allHit = GameObject.FindGameObjectsWithTag("HitObject");
        int hitObjectStatusCounter = 0;
        for (int i = 0; i < allHit.Length; i++)
        {
            hitObjectStatusCounter++;
        }

        if (hitObjectStatusCounter <= 0)
        {
            Debug.Log("No hit found");
            bottom_panel.SetActive(true);
            completeScreen.SetActive(true);
        }
        else
        {
            Debug.Log("hit true");
        }

    }
    /*Hiding the OST afte some time - ENS*/

    /*Showing a particular OST and hiding others------------------------------------*/
    void showOST(GameObject OST_popup, int hideTime)
    {
        hideAllOST();
        OST_popup.SetActive(true);
        bottom_panel.SetActive(true);
        OST_coroutine = StartCoroutine(hideTheOSTPopUp(OST_popup, hideTime));
        ost_status = true;
    }
    /*Showing a particular OST and hiding others - END*/
    
     
}
