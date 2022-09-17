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
        rotY += Input.GetAxis("Mouse X");
        rotX += Input.GetAxis("Mouse Y");

        transform.rotation = Quaternion.Euler(-rotX * sensitivity, rotY * sensitivity, 0);
        
        movement = transform.forward;
        movement = new Vector3(movement.x, 0f, movement.z);
    }
}