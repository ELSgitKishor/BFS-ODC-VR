using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public bool rotate = false;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(rotate){
            transform.Rotate(Vector3.up, 10 * Time.deltaTime);
        }
    }

    public void rotateCube(bool rotateStatus){       
        rotate = rotateStatus;        
    }
}
