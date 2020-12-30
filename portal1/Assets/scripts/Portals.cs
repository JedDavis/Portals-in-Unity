using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    public float diff;

    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        playerOffsetFromPortal = Quaternion.Euler(portal.eulerAngles.x - otherPortal.eulerAngles.x, portal.eulerAngles.y - otherPortal.eulerAngles.y, portal.eulerAngles.z - otherPortal.eulerAngles.z) * playerOffsetFromPortal;
        playerOffsetFromPortal.y *= -1;
        transform.position = portal.position - playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = portal.rotation.eulerAngles.y - otherPortal.rotation.eulerAngles.y;

        if (angularDifferenceBetweenPortalRotations > -1 && angularDifferenceBetweenPortalRotations < 1)
        {
            diff = 0;
        }
        else if (angularDifferenceBetweenPortalRotations > 179 && angularDifferenceBetweenPortalRotations < 181 || angularDifferenceBetweenPortalRotations > -181 && angularDifferenceBetweenPortalRotations < -179)
        {
            diff = 180;
        }
        else if (angularDifferenceBetweenPortalRotations > -271 && angularDifferenceBetweenPortalRotations < -268)
        {
            diff = 90;
        }
        else if (angularDifferenceBetweenPortalRotations > 269 && angularDifferenceBetweenPortalRotations < 271)
        {
            diff = -90;
        }
        else if (angularDifferenceBetweenPortalRotations > 89 && angularDifferenceBetweenPortalRotations < 91)
        {
            diff = 90;
        }
        else if (angularDifferenceBetweenPortalRotations > -91 && angularDifferenceBetweenPortalRotations < -89)
        {
            diff = -90;
        }      

        angularDifferenceBetweenPortalRotations = diff;
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward * -1;
        transform.localRotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        transform.localRotation = new Quaternion(transform.localRotation.x, -transform.localRotation.y, transform.localRotation.z, -transform.rotation.w);        
    }


}
