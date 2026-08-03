using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    // Start is called before the first frame update
    public static Animator animator;
    
    public static bool spc = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void jumpObject(){
        Debug.Log("Jump Object .............................");
        animator.SetInteger("jump", 1);
    }

}
