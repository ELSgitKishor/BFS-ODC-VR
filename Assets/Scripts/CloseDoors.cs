using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Oculus.Interaction
{
    public class CloseDoors : MonoBehaviour
    {
        public GameObject door_R, room1;
        public IDCardManager _iDCardManager; 
        // Start is called before the first frame update
        void Start()
        {

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
           

            _iDCardManager.CloseDoor();
        }
    }
}