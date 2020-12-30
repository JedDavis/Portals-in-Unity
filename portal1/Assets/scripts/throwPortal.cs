using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwPortal : MonoBehaviour
{
    public GameObject leftPortal;
    public GameObject left_cam;
    public GameObject rightPortal;
    public GameObject right_cam;
    public GameObject mainCamera;


    public int left_throw_count = 0;
    public int right_throw_count = 0;

    void Start()
    {
        leftPortal.SetActive(false);
        rightPortal.SetActive(false);
        left_cam.SetActive(false);
        right_cam.SetActive(false);

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            throwportal(leftPortal);
            left_throw_count++;
            if(left_throw_count > 0)
            {
                leftPortal.SetActive(true);
                left_cam.SetActive(true);
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            throwportal(rightPortal);
            right_throw_count++;
            if (right_throw_count > 0)
            {
                rightPortal.SetActive(true);
                right_cam.SetActive(true);
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            left_throw_count = 0;
            right_throw_count = 0;
            leftPortal.SetActive(false);
            rightPortal.SetActive(false);
            left_cam.SetActive(false);
            right_cam.SetActive(false);
        }
    }

    void throwportal(GameObject portal)
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Quaternion hitObjectRotation = Quaternion.LookRotation(-hit.normal);
            portal.transform.position = hit.point;
            portal.transform.rotation = hitObjectRotation;
        }
    }
}
