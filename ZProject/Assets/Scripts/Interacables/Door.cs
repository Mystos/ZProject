using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public int cost;
    public uint roomIdA;
    public uint roomIdB;

    private Animator anim;
    private bool opened = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void Interact(GameObject playerRoot)
    {
        if (opened)
            return;

        PlayerGear playerGear = playerRoot.GetComponent<PlayerGear>();
        if (playerGear)
        {
            TryOpen(playerGear);
        }
        else
            Debug.LogError("Can't find PlayerGear in " + playerRoot.name);
    }

    public override void ShowInteractionInterface()
    {
        if (opened)
            return;

        UIManager.Instance.ShowInteractionPanel($"Open door ({cost}$)");
    }

    public override void HideInteractionInterface()
    {
        UIManager.Instance.HideInteractionPanel();
    }


    public void TryOpen(PlayerGear playerGear)
    {
        if (playerGear.Buy(cost))
        {
            anim.Play("Open");
            opened = true;
            GameManager.Instance.UpdateAccessibleRooms(this);
        }
        else
            Debug.Log("Not enough money to open door");

    }

}
