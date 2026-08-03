using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Oculus.Interaction
{
    public class PlayerMovement : MonoBehaviour
    {
        public GameObject door_R,room1,room;
        public IDCardManager _iDCardManager;
        public float movementSpeed = 3f;
        public float rotationspeed = 90f;
        public CharacterController _CharacterController;
        public OVRPlayerController _OVRPlayerController;
        // Start is called before the first frame update
        void Start()
        {
            //  _CharacterController = GetComponent<CharacterController>();
            //_OVRPlayerController = GetComponent<OVRPlayerController>();

        }

        // Update is called once per frame
        void Update()
        {
            float horizontalmovement = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
            float verticalMovement = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
            float rotate = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;

            //player movement
            Vector3 movement = transform.forward * verticalMovement + transform.right * horizontalmovement;
            _CharacterController.Move(movement * movementSpeed * Time.deltaTime);

            //player Rotation
            transform.Rotate(Vector3.up, rotate * rotationspeed * Time.deltaTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Close_door")
            {
                Invoke("closeDoor", 0.5f);
            }
             if (other.gameObject.name == "Close")
            {
                Invoke("closeDoor", 0.5f);
            }


        }
        public void closeDoor()
        {
            //door_R.transform.rotation = Quaternion.Euler(0, 2, 0);
            door_R.GetComponent<Animator>().SetInteger("Open", 2);
            room1.GetComponent<Animator>().SetInteger("Open", 2);
            room.GetComponent<Animator>().SetInteger("Open", 2);
            

            _iDCardManager.CloseDoor();
        }
    }
}