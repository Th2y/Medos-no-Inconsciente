using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisaoMouse : MonoBehaviour
{
    public float sensibilidadeMouse = 100f;

    public Transform corpoPlayer;

    float xRotacao = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;

        xRotacao -= mouseY;
        xRotacao = Mathf.Clamp(xRotacao, -90f, 50f);

        transform.localRotation = Quaternion.Euler(xRotacao, 0f, 0f);
        corpoPlayer.Rotate(Vector3.up * mouseX);
    }
}
