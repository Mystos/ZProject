using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    // If the object is destroyed while being INSIDE the list, it will remain in it permanently
    // Then the object should remove itself from the list before being destroyed

    public List<Collider> interactableColliders;
    public Collider selectedInteraction;

    void Start() {
        interactableColliders = new List<Collider>();
        selectedInteraction = null;
    }

    void Update() {

        // If empty, we hide the latest selected if it exist
        if (interactableColliders.Count == 0) {
            if (selectedInteraction != null) {
                selectedInteraction.GetComponent<Interactable>().HideInteractionInterface();
                selectedInteraction = null;
            }
            //Else nothing happens
        }
        else { // If not empty, we find the closest one, replace the selected one by the closest and show it

            Collider closestCollider = interactableColliders[0];
            float closestDistance = Vector3.Distance(transform.position, closestCollider.transform.position);

            for (int i = 1; i < interactableColliders.Count; i++) {

                float newDistance = Vector3.Distance(transform.position, interactableColliders[i].transform.position);
                if (newDistance < closestDistance) {
                    closestDistance = newDistance;
                    closestCollider = interactableColliders[i];
                }

            }

            if (selectedInteraction != null) {
                selectedInteraction.GetComponent<Interactable>().HideInteractionInterface();
            }

            selectedInteraction = closestCollider;

            selectedInteraction.GetComponent<Interactable>().ShowInteractionInterface();

        }

        if (Input.GetButtonDown("Interact") && CanInteract()) {
            Debug.Log("Interaction");
            selectedInteraction.GetComponent<Interactable>().Interact();
        }
        
    }

    // We can add stuff like 'isGrounded' or anything we need here
    private bool CanInteract() {
        return selectedInteraction != null;
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Added : " + other.name);
        interactableColliders.Add(other);
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("Removed : " + other.name);
        interactableColliders.Remove(other);
    }

}
