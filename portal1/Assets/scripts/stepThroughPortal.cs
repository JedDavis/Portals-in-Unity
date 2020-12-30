using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepThroughPortal : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    public PlayerMovement moving;
    public mouseLook rotating;

    public float diff;
    
    private bool playerIsOverLapping = false;
    private bool teleporting = false;
    
    void Update()
    {

        if (playerIsOverLapping && !moving.isTele)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float portalSide = Vector3.Dot(portalToPlayer, transform.up);           

            if (portalSide != 0)
            {                
                moving.movementEnabled = false;
                rotating.rotation_enabled = false;
                moving.isTele = true;

                float rotationDiff = transform.rotation.eulerAngles.y - reciever.rotation.eulerAngles.y;

                if (rotationDiff > -1 && rotationDiff < 1)
                {
                    diff = 180;
                }
                else if (rotationDiff > 179 && rotationDiff < 181 || rotationDiff > -181 && rotationDiff < -179)
                {
                    diff = 0;
                }
                else if(rotationDiff > -271 && rotationDiff < -268)
                {
                    diff = 90;
                }
                else if(rotationDiff > 269 && rotationDiff < 271)
                {
                    diff = -90;
                }
                else if(rotationDiff > 89 && rotationDiff < 91)
                {
                    diff = 90;
                }
                else if (rotationDiff > -91 && rotationDiff < -89)
                {
                    diff = -90;
                }
                


                player.Rotate(Vector3.up, diff);

                Vector3 positionOffset = Quaternion.Euler(0f, diff, 0f) * portalToPlayer;

                moving.movement = reciever.position + positionOffset;
                rotating.rotation2 = player.rotation;
                playerIsOverLapping = false;                
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (moving.isTele)
            {
                teleporting = true;
                moving.movementEnabled = true;
                rotating.rotation_enabled = true;
            }
            playerIsOverLapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (teleporting)
            {
                teleporting = false;
                moving.isTele = false;
            }
            playerIsOverLapping = false;
        }
    }
}
