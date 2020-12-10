using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLight : Interactable
{

    public bool IsOn;
    public Light sphereLight;

    void Start() {
        IsOn = true;
        sphereLight = GetComponent<Light>();
    }

    public override void Interact() {
        IsOn = !IsOn;

        if (IsOn) {
            sphereLight.enabled = true;
        } else {
            sphereLight.enabled = false;
        }
    }

    public override void ShowInteractionInterface() {
        //Debug.Log("Can interact with me !");
    }

    public override void HideInteractionInterface() {
        //Debug.Log("Cannot interact with me anymore :(");
    }
}
