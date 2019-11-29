using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject hinge;
    public GameObject openDoorRotationDummy;
    public GameObject closeDoorRotationDummy;

    private bool isAnimating;
    private bool isOpening;
    private bool isClosing;
    private Quaternion targetRot;


    public void OpenDoor() {
        if (isAnimating) {
            StopCoroutine(AnimateDoor());
        }
        if (!isOpening) {
            isOpening =true;
            isAnimating=true;
            targetRot = openDoorRotationDummy.transform.rotation;
            StartCoroutine(AnimateDoor());
            isClosing=false;
        }
        
        
    }
    public void CloseDoor() {
        if (isAnimating) {
            StopCoroutine(AnimateDoor());
        }
        if (!isClosing) {
            isClosing = true;
            isAnimating = true;
            targetRot = closeDoorRotationDummy.transform.rotation;
            StartCoroutine(AnimateDoor());
            isOpening = false;
        }
    }

    private IEnumerator AnimateDoor() {
        float currentTime=0;
        float animationDuration = 1;
        while(currentTime<animationDuration) {
            hinge.transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                currentTime/animationDuration
            );
            currentTime+=Time.deltaTime;
            yield return null;
        }
        hinge.transform.rotation = targetRot;
        isAnimating = false;

    }
}
