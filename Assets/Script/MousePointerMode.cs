using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointerMode : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorHover;

    // Use this for initialization
    void Start() {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }
    void OnMouseEnter()
    {       
        Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.ForceSoftware);        
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }
}
