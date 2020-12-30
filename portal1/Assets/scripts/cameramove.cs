using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public float rotationSpeed;
    private void Start()
    {
        rotationSpeed = -100f;
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime,0f, 0f);
    }
}
