using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOf_PlayerHit : MonoBehaviour
{
    public GameObject[] colliders;
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
            foreach (var collider in colliders)
            {
                collider.SetActive(false);
            }
        }
    }
}
