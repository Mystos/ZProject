using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public int cost;
    public uint roomId;

    public Animation openAnim;

    public void TryOpen()
    {
    }

    private void Unlock()
    {
      
    }

    public override void HideInteractionInterface()
    {
        throw new System.NotImplementedException();
    }

    public override void Interact(GameObject playerRoot)
    {
        throw new System.NotImplementedException();
    }

    public override void ShowInteractionInterface()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
