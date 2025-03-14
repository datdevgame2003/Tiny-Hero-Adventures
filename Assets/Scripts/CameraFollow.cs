using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraFollow : MonoBehaviour
{
    public Transform target; // Nhân vật
    public float smoothSpeed = 0.125f; // Tốc độ di chuyển camera
    public Vector3 offset = new Vector3(0, 2f, -10f); // Giữ tầm nhìn bên dưới
    //private void Start()
    //{
    //    //CinemachineVirtualCamera virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    //    //if (virtualCamera != null)
    //    //{
    //    //    virtualCamera.Follow = transform;
    //    //}

    //}
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}

