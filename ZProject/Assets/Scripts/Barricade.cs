using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    // First plank = first to be destroyed and last to be repaired
    public int nextPlank = 0;
    public List<GameObject> planks;

    public bool isBeingDestroyed = false;

    //Destroy cooldown
    public float destroyCooldown = 0.8f;
    public float destroyTimer = 0.0f;

    //Repair cooldown
    public float repairCooldown = 1.0f;
    public float repairTimer = 0.0f;

    private void Start() {
        destroyTimer = destroyCooldown;
        repairTimer = repairCooldown;
    }

    private void Update() {
        destroyTimer += Time.deltaTime;
        repairTimer += Time.deltaTime;

        Debug.Log(isOpen());
    }


    public void destroyBarricade() {

        // If all planks are already destroyed
        if (nextPlank == planks.Count) {
            return;
        }

        // Checking cooldown
        if (destroyTimer < destroyCooldown) {
            return;
        }

        // Destroy plank : reset cooldown, set plank "nextPlank" unactive, increment "nextPlank"
        destroyTimer = 0.0f;
        planks[nextPlank].SetActive(false);
        nextPlank++;

    }

    public void repairBarricade() {

        // If all planks are already repaired
        if (nextPlank == 0) {
            return;
        }

        // Checking if this barricade is being destroyed
        if (isBeingDestroyed) {
            return;
        }

        // Checking cooldown
        if (repairTimer < repairCooldown) {
            return;
        }

        // Repair plank : reset cooldown, set plank "nextPlank - 1" active, decrement "nextPlank"
        repairTimer = 0.0f;
        planks[nextPlank - 1].SetActive(true);
        nextPlank--;

    }

    private bool isOpen() {
        // Only if every child is not active
        return nextPlank == planks.Count;
    }

    //Test method
    private void OnMouseOver() {

        if (Input.GetMouseButton(0)) {
            isBeingDestroyed = true;
            destroyBarricade();
        } else {
            isBeingDestroyed = false;
        }

        if (Input.GetMouseButton(1)){
            repairBarricade();
        }

    }

}
