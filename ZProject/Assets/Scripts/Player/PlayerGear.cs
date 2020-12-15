using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGear : MonoBehaviour
{
    public int startMoney;
    private int currentMoney;

    void Start()
    {
        currentMoney = startMoney;
    }


    public bool Buy(int price)
    {
        if (currentMoney - price >= 0)
        {
            currentMoney -= price;
            return true;
        }
        else
            return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectable collectable = other.GetComponent<Collectable>();
        if (collectable)
        {
            collectable.Collect(gameObject);
        }
    }
}
