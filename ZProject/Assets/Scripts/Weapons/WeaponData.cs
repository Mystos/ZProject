using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons", order = 1)]
public class WeaponData : ScriptableObject
{
    public string name = "FireWeapon";
    public float baseDamages;
    public float upgradeFactor;

    public int cost;
    public int loaderMaxCapacity;
    public int maxCapacity;
    public int range;
    public float reloadTime = 1f;
    public float fireRate = 0f;
    public float bulletSpeed;
}

