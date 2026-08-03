using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColliderOff_Player : MonoBehaviour
{
    public float time=1f;
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
        if (other.gameObject.name == "OculusInteractionSampleRig")
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
            Invoke("Activate_collider", time);
        }
    }

    public void Activate_collider()
    {
        this.gameObject.GetComponent<Collider>().enabled = true;

    }
}
