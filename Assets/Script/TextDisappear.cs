using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisappear : MonoBehaviour
{    
    private float hideTime = 5.0f;
    public AudioSource audioSource; /*Audio player*/
    private void Start() {
        StartCoroutine(hideTheText());
    }

    /*private void OnCollisionEnter(Collision other) {     
        audioSource.Play();   
        StartCoroutine(hideTheText());
    }*/

    IEnumerator hideTheText() {   
        yield return new WaitForSeconds(hideTime); 
        transform.gameObject.SetActive(false);
        
    }
}
