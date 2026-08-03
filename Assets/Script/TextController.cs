using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    // Start is called before the first frame update
    public static string hitName;
    public Text console_text;
    void Start()
    {
        hitName = "Hit obj name";
    }

     void Update()
    {
        transform.GetComponent<Text>().text = hitName;
    }
    

     public static void hitObject(string hitObj){
        Debug.Log("Hit Object ............................."+hitObj);
        hitName = hitObj;
    }
}
