using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Oculus.Interaction
{
public class SwipMachine : MonoBehaviour
{
    MeshRenderer MeshRenderer;
    public Material red;
    public Material green;

    public bool openDoor=false;
    // Start is called before the first frame update
    void Start()
    {
      //  MeshRenderer.material = red;
    }

    public void DoorPermission()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //if (openDoor)
        //{
        //    MeshRenderer.material =green;
        //}
        //else
        //{
        //    MeshRenderer.material = red;
        //}
    }
}
}