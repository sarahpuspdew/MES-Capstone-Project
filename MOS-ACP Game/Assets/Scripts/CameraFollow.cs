using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera mainCam;
    Vector3 offset;
    Vector3 camPos;

    void Start()
    {
        mainCam = Camera.main;
        offset = SetCamPos();
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }

    Vector3 SetCamPos()
    {
        float camPosX = mainCam.transform.position.x;
        float camPosY = mainCam.transform.position.y;
        float camPosZ = mainCam.transform.position.z;
        camPos = new Vector3(camPosX, camPosY, camPosZ);

        return camPos;
    }
}