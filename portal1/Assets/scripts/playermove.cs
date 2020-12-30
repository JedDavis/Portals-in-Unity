using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    private void Start()
    {
        moveSpeed = 3f;
        rotationSpeed = 500f;
    }

    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Rotate(0f, rotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, 0f);
    }
}
