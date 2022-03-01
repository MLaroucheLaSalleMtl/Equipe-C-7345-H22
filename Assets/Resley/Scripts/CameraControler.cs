using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZomm = 5f;
    public float maxZomm = 15f;

    private float currentZoom = 10f;

    private float pitch = 2f;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZomm, maxZomm);
    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
