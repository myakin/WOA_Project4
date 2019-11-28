using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    public float jumpMagnitude;
    private float ver, hor, mouseY, mouseX, jump, fire1;

    
    private void Update() {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        mouseY = Input.GetAxis("Mouse Y");
        mouseX = Input.GetAxis("Mouse X");
        jump = Input.GetAxis("Jump");
        fire1 = Input.GetAxis("Fire1");
        
        if (ver!=0) {
            MoveForwardBack();
        }
        if (hor!=0) {
            MoveLeftRight();
        }
        TurnLeftRight();

    }


    private void MoveForwardBack() {
        transform.position += (transform.forward * (ver * moveSpeed));
    }
    private void MoveLeftRight() {
        transform.position += (transform.right * (hor * moveSpeed));
    }

    private void TurnLeftRight() {
        transform.rotation *= Quaternion.Euler(0, mouseX * rotSpeed, 0);
    }

    private void LookUpDown() {

    }

    private void Jump() {

    }

    private void Fire() {

    }
}
