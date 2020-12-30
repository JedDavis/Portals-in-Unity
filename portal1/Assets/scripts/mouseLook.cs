using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    public float mouseSence = 250f;

    public Transform playerBody;
    
    public Quaternion rotation;

    public Quaternion rotation2;

    public bool rotation_enabled = true;

    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotation_enabled)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSence * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSence * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.transform.Rotate(Vector3.up * mouseX);
        }
        else
        {
            transform.rotation = rotation2;
        }
    }    
}
