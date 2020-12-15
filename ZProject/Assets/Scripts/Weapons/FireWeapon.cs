using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWeaponType { Pistol, Shotgun, Smg, Sniper, MachineGun }

public class FireWeapon : MonoBehaviour
{
    public WeaponData data;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject fireEffectPrefab;
    [SerializeField] GameObject[] upgradeGraphics;

    public float CurrentDamages { get; private set; }
    public float FireRate { get; private set; }
    public float Range { get; private set; }
    public float ReloadTime { get; private set; }
    public int LoaderAmount { get; private set; }
    public int MaxLoaderCapacity { get; private set; }
    public int BulletsAmount { get; private set; }
    //public int MaxBullets { get; private set; }


    private GameObject currentGraphics;
    private int upgradeLevel = 1;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        CurrentDamages = data.baseDamages;
        FireRate = data.fireRate;
        Range = data.range;
        ReloadTime = data.reloadTime;
        LoaderAmount = data.loaderMaxCapacity;
        MaxLoaderCapacity = data.loaderMaxCapacity;
        BulletsAmount = data.maxCapacity;
        //MaxBullets = data.maxCapacity;

        if (upgradeGraphics.Length > 0)
            currentGraphics = upgradeGraphics[0];
    }

    public void Fire()
    {
        BulletsAmount--;
        GameObject go = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(transform.forward, transform.up));
        Bullet bullet = go.GetComponent<Bullet>();
        if (bullet)
        {
            bullet.Velocity = data.bulletSpeed;
        }
    }

    public void Equip()
    {
        currentGraphics.SetActive(true);
    }

    public void Refill()
    {
        int refillAmount = MaxLoaderCapacity - LoaderAmount;

        if (BulletsAmount >= refillAmount)
        {
            LoaderAmount = MaxLoaderCapacity;
            BulletsAmount -= refillAmount;
        }
        else
        {
            LoaderAmount += BulletsAmount;
            BulletsAmount = 0;
        }
    }

    public void Unequip()
    {
        for (int i = 0; i < upgradeGraphics.Length; i++)
        {
            upgradeGraphics[i].SetActive(false);
        }
    }

    public void UpgradeWeapon()
    {
        upgradeLevel++;
        if (upgradeLevel < upgradeGraphics.Length)
        {
            currentGraphics = upgradeGraphics[upgradeLevel];
        }

        CurrentDamages = data.baseDamages * data.upgradeFactor;
    }


}
