using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDispenser : Interactable
{
    [SerializeField] Transform weaponPosition;
    [SerializeField] FireWeapon weaponPrefab;
    [SerializeField] float rotSpeed = 1f;
    private GameObject weaponGraphics;


    public override void HideInteractionInterface()
    {
        UIManager.Instance.HideInteractionPanel();
    }

    public override void Interact(GameObject playerRoot)
    {
        PlayerShooter playerShooter = playerRoot.GetComponent<PlayerShooter>();
        PlayerGear playerGear = playerRoot.GetComponent<PlayerGear>();
        if (playerShooter && playerGear)
        {
            if (playerGear.Buy(weaponPrefab.data.cost))
                playerShooter.PickUpWeapon(weaponPrefab);
            else
                Debug.Log("Not enough money to buy " + weaponPrefab.data.name);
        }
        else
            Debug.LogError("Can't find PlayerShooter or PlayerGear in " + playerRoot.name);
    }

    public override void ShowInteractionInterface()
    {
        UIManager.Instance.ShowInteractionPanel($"Buy {weaponPrefab.data.name} ({weaponPrefab.data.cost}$)");
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponGraphics = Instantiate(weaponPrefab.gameObject, weaponPosition);

    }

    // Update is called once per frame
    void Update()
    {
        weaponGraphics.transform.Rotate(Vector3.up, rotSpeed);
    }
}
