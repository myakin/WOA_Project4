using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryMe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            // UI'a mesaj gonder
        }
    }
}
