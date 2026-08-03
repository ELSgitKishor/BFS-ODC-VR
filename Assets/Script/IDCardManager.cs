using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Oculus.Interaction
{
    public class IDCardManager : MonoBehaviour
    {
        public GameObject door_R,door_C,door_W, door_cabin, door_cabin_exit, door_cabin_7;
        public GameObject swip_macine_R,swip_machine_R2, Swipe_mechine_C, Swipe_mechine_C1, Swipe_mechine_W, Swipe_mechine_W1, Swipe_mechine_exit;
         
        // Start is called before the first frame update
        void Start()
        {
            //door_R.GetComponent<Grabbable>().enabled = false;hh
            //door_R.GetComponent<GrabInteractable>().enabled = false;kk
            // door_R.GetComponent<OneGrabRotateTransformer>().enabled = false;

            swip_macine_R.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            swip_machine_R2.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            Swipe_mechine_C.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            Swipe_mechine_C1.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            Swipe_mechine_W.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
             Swipe_mechine_W1.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            Swipe_mechine_exit.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;

        }
        public void CloseDoor()
        {

            swip_macine_R.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            swip_machine_R2.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            Swipe_mechine_C.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            Swipe_mechine_C1.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            Swipe_mechine_W.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            Swipe_mechine_W1.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
            Swipe_mechine_exit.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
           
            door_R.GetComponent<Animator>().SetInteger("Open", 2);
            door_C.GetComponent<Animator>().SetInteger("Open", 2);
            door_W.GetComponent<Animator>().SetInteger("Open", 2);

            door_cabin.GetComponent<Animator>().SetInteger("Open", 2);
            door_cabin_exit.GetComponent<Animator>().SetInteger("Open", 2);
            door_cabin_7.GetComponent<Animator>().SetInteger("Open", 2);


        }
        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name== "Swipe_mechine_R")
            {
                Debug.Log("swipe machine_ R");
                swip_macine_R.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
                swip_machine_R2.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
                door_R.GetComponent<Animator>().SetInteger("Open", 1);
                 
            }

            if(other.gameObject.name== "Swipe_mechine_C")
            {
                Swipe_mechine_C.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
                door_C.GetComponent<Animator>().SetInteger("Open", 1);
            }
            if(other.gameObject.name== "Swipe_mechine_W")
            {
                Swipe_mechine_W.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
                door_W.GetComponent<Animator>().SetInteger("Open", 1);
            }
             if(other.gameObject.name== "Swipe_mechine_EE")
            {
                Swipe_mechine_exit.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
                door_cabin_exit.GetComponent<Animator>().SetInteger("Open", 1);
            }
        }
    }
}