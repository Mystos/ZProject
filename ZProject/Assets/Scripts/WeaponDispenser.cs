using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDispenser : Interactable
{
    public Transform weaponPosition;
    public GameObject weaponPrefab;
    private GameObject weaponGraphics;

    private float rotSpeed = 1f;

    public override void HideInteractionInterface()
    {
        throw new System.NotImplementedException();
    }

    public override void Interact()
    {
        throw new System.NotImplementedException();
    }

    public override void ShowInteractionInterface()
    {
        ;
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponGraphics = Instantiate(weaponPrefab, weaponPosition);

    }

    // Update is called once per frame
    void Update()
    {
        weaponGraphics.transform.Rotate(Vector3.up, 1);
    }
}
