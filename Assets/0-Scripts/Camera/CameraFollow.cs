using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followDistance = 3f;
    public float upOffset = 1.7f;
    public float rightOffset = 0;
    public float xRotation = -5f;
    public float yRotation = 0;
    public float dampeningFactor = 0.01f;
    private Vector3 offset;

    

    private void LateUpdate() {
        // kameram oyuncunun pozisyonunun followDistance kaar arkasina olacak
        // kameramin poziyonu + (oyuncumun arka yonu * followDistance)
        transform.position = target.position + (-target.forward * followDistance) + (transform.up * upOffset) + (transform.right * rightOffset);
        transform.rotation = (target.rotation * Quaternion.Euler(xRotation, yRotation , 0));
    }

    public void SmoothMovemet(Vector3 aTargetPosition) {
        offset += aTargetPosition;
        Vector3 oldPos = transform.position;
        Vector3 newPos = Vector3.LerpUnclamped(oldPos, aTargetPosition, dampeningFactor);
        transform.position = newPos;
        offset -= newPos - oldPos;
    }
}
