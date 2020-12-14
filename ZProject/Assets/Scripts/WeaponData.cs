using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons", order = 1)]
public class FireWeaponData : ScriptableObject
{
    public string name = "Glock";
    public float baseDamages;
    public float upgradeFactor;
    public int level = 1;

    public int cost;
    public int loaderCapacity;
    public int loaderMaxCapacity;
    public int maxCapacity;
    public float reloadTime = 1f;
    public float fireRate = 0f;
    public GameObject graphics;


    public GameObject mesh;

}

public enum EWeaponType { Pistol, Shotgun, Smg, Sniper, MachineGun}
