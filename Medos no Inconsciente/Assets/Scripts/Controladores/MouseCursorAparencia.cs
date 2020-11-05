using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursorAparencia : MonoBehaviour
{
    public Texture2D cursorMenu;

    public static bool mouseOn;

    private void Start()
    {
        Cursor.SetCursor(cursorMenu, Vector2.zero, CursorMode.Auto);
        if (SceneManager.GetActiveScene().name == "Menu")
            mouseOn = true;
        else
            mouseOn = false;
    }

    private void FixedUpdate()
    {
        {
            if(!mouseOn)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorMenu, Vector2.zero, CursorMode.Auto);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
