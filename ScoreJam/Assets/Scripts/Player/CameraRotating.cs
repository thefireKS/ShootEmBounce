using System;
using UnityEngine;

public class CameraRotating : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float minAngle, maxAngle;
    private float _xRotation, _yRotation;
    // public Vector3 movement;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        _yRotation += mouseX;
        _xRotation += mouseY;
        
        _xRotation = Mathf.Clamp(_xRotation, minAngle, maxAngle);

        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        
        /*if (Time.timeScale != 0f)
        {
            _rotY += Input.GetAxis("Mouse X");
            _rotX += Input.GetAxis("Mouse Y");

            _rotX *= sensitivity;
            _rotY *= sensitivity;
            _rotY = Mathf.Clamp(_rotY, minAngle, maxAngle);

            transform.rotation = Quaternion.Euler(-_rotX, _rotY, 0);

            if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButton(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            if (Input.GetMouseButton(1))
                Camera.main.fieldOfView = 60;
            else
                Camera.main.fieldOfView = 75;
        }*/
    }
}