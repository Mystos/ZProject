using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySource : Collectable
{
    public int amount;

    public override void Collect(GameObject playerRoot)
    {
       PlayerGear gear = playerRoot.GetComponent<PlayerGear>();
        if (gear)
        {

        }
        else
            Debug.LogError("Can't find PlayerGear in " + playerRoot.name);
    }
}
