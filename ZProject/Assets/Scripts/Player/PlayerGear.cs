using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGear : MonoBehaviour
{
    public int startMoney;
    public int CurrentMoney { get; private set; }

    void Start()
    {
        CurrentMoney = startMoney;
    }


    public bool Buy(int price)
    {
        if (CurrentMoney - price >= 0)
        {
            CurrentMoney -= price;
            return true;
        }
        else
            return false;
    }

    public void AddMoney(int amount)
    {
        CurrentMoney += amount;
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
