using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotating : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float sensitivity;
    private float rotX, rotY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            gameObject.GetComponentInParent<Rigidbody>().velocity = transform.forward * 25f;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
            bul.GetComponent<Rigidbody>().velocity = transform.forward * 40f;
            Destroy(bul, 5f);
        }
        rotY += Input.GetAxis("Mouse X");
        rotX += Input.GetAxis("Mouse Y");

        transform.rotation = Quaternion.Euler(-rotX * sensitivity, rotY * sensitivity, 0);
    }
}
