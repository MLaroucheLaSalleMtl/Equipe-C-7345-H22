using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Variables d'entre
    KeyCode leftMouse = KeyCode.Mouse0, rightMouse = KeyCode.Mouse1, middleMouse = KeyCode.Mouse2;

    //Variables de Camera
    public float cameraHeight = 1.75f, cameraMaxDistance = 25;
    float cameraMAxTilt = 80;
    [Range(0, 4)]
    public float cameraSpeed = 2;
    float currentPan, currentTilt = 10, currentDistance = 5;

    //Cam States
    public CameraState cameraState = CameraState.cameraNone;

    //References
    Player player;
    public Transform tilt;
    Camera mainCam;

    void Start()
    {
        player = FindObjectOfType<Player>();
        mainCam = Camera.main;

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.rotation = player.transform.rotation;

        tilt.eulerAngles = new Vector3(currentTilt, transform.eulerAngles.y, transform.eulerAngles.z);
        mainCam.transform.position += tilt.forward * -currentDistance;
    }


    void Update()
    {
        if (!Input.GetKey(leftMouse) && !Input.GetKey(rightMouse) && !Input.GetKey(middleMouse))
            cameraState = CameraState.cameraRun;
        else if (Input.GetKeyDown(rightMouse))
            cameraState = CameraState.cameraRotate;

        CameraInputs();
    }

    private void LateUpdate()
    {
        CameraTransforms();
    }

    void CameraInputs()
    {
        if(cameraState != CameraState.cameraNone)
        {
            if (cameraState == CameraState.cameraRotate)
                currentPan -= Input.GetAxis("Mouse X") * cameraSpeed;
            if (cameraState == CameraState.cameraRotate)
                currentTilt -= Input.GetAxis("Mouse Y") * cameraSpeed;
            currentTilt = Mathf.Clamp(currentTilt,-0, cameraMAxTilt);
        }

        currentDistance -= Input.GetAxis("Mouse ScrollWheel") * 2;
        currentDistance = Mathf.Clamp(currentDistance, 0, cameraMaxDistance);
    }


    void CameraTransforms ()
    {
        switch(cameraState)
        {
            case CameraState.cameraNone:
                currentPan = player.transform.eulerAngles.y;
                currentTilt = 10;
                break;
        }

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentPan, transform.eulerAngles.z);
        tilt.eulerAngles = new Vector3(currentTilt, tilt.eulerAngles.y, tilt.eulerAngles.z);
        mainCam.transform.position = transform.position + tilt.forward * -currentDistance;
    }

    public enum CameraState { cameraNone, cameraRotate, cameraRun}
}
