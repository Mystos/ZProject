using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    // If the object is destroyed while being INSIDE the list, it will remain in it permanently
    // Then the object should remove itself from the list before being destroyed

    private List<Interactable> interactableObjects;
    private Interactable selectedInteraction;

    void Start()
    {
        interactableObjects = new List<Interactable>();
        selectedInteraction = null;
    }

    void Update()
    {

        // If empty, we hide the latest selected if it exist
        if (interactableObjects.Count == 0)
        {
            if (selectedInteraction != null)
            {
                selectedInteraction.GetComponent<Interactable>().HideInteractionInterface();  //To be replaced by UIManager.Instance.HideInteractionPanel();  ?
                selectedInteraction = null;
            }
            //Else nothing happens
        }
        else
        { // If not empty, we find the closest one, replace the selected one by the closest and show it

            Interactable closest = interactableObjects[0];
            float closestDistance = Vector3.Distance(transform.position, closest.transform.position);

            for (int i = 1; i < interactableObjects.Count; i++)
            {
                float newDistance = Vector3.Distance(transform.position, interactableObjects[i].transform.position);
                if (newDistance < closestDistance)
                {
                    closestDistance = newDistance;
                    closest = interactableObjects[i];
                }
            }

            if (selectedInteraction != null)
            {
                selectedInteraction.GetComponent<Interactable>().HideInteractionInterface();
            }

            selectedInteraction = closest;
            selectedInteraction.ShowInteractionInterface();
        }

        if (CanInteract())
        {
            if (Input.GetButtonDown("Interact"))
            { // Here, we can add "holding" interaction for some objects
                selectedInteraction.GetComponent<Interactable>().Interact(gameObject);
            }
        }

    }

    // We can add stuff like 'isGrounded' or anything we need here
    private bool CanInteract()
    {
        return selectedInteraction != null;
    }

    void OnTriggerEnter(Collider other)
    {
        Interactable interactObj = other.GetComponent<Interactable>();
        if (interactObj)
            interactableObjects.Add(interactObj);
    }

    void OnTriggerExit(Collider other)
    {
        Interactable interactObj = other.GetComponent<Interactable>();
        if (interactableObjects.Contains(interactObj))
            interactableObjects.Remove(interactObj);
    }

}
