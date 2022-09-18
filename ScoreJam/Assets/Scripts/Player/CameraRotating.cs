using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotating : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    private float rotX, rotY;
    public Vector3 movement;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Time.timeScale != 0f)
        {
            rotY += Input.GetAxis("Mouse X");
            rotX += Input.GetAxis("Mouse Y");

            transform.rotation = Quaternion.Euler(-rotX * sensitivity, rotY * sensitivity, 0);
        
            movement = transform.forward;
            movement = new Vector3(movement.x, 0f, movement.z);

            if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButton(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            if (Input.GetMouseButton(1))
                Camera.main.fieldOfView = 60;
            else
                Camera.main.fieldOfView = 75;
        }
    }
}