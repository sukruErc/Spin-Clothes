using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow360 : MonoBehaviour
{

    public Transform player;
    public float distance = 10;
    public float height = 5;
    public Vector3 lookOffset = new Vector3(0, 1, 0);
    float cameraSpeed = 100;

    void FixedUpdate()
    {
        if (player)
        {
            Vector3 targetPos = player.transform.position + player.transform.up * height - player.transform.forward * distance;
            targetPos.x = 0; //for the camera lock to x position
            targetPos.z = player.transform.position.z-6f;
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * cameraSpeed * 0.1f);
        }
    }

    public void IncreaseHeight()
    {
        height = height + 0.5f;
    }
    public void DecreaseHeight()
    {
        height = height - 0.5f;
    }
}
