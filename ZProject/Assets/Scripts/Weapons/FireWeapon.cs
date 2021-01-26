using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWeaponType { Pistol, Shotgun, Smg, Sniper, MachineGun }

public class FireWeapon : MonoBehaviour {
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

    private float timer = 0f;

    private GameObject currentGraphics;
    private int upgradeLevel = 1;

    public GameObject test;

    void Start() {
        Init();
    }

    public void Init() {
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

    private void Update() {

        if (timer > 0) {
            timer -= Time.deltaTime;
        }
    }

    public void Fire() {

        if (timer > 0)
            return;

        AudioManager.instance.Play(data.name);
        LoaderAmount--;
        timer = 1 / FireRate;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject go = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward, Vector3.up));
        if (Physics.Raycast(ray, out hit, GameManager.Instance.groundLayer)) {
            Vector3 target = new Vector3(hit.point.x, firePoint.transform.position.y, hit.point.z);
            if (Vector3.Angle(firePoint.forward, target - firePoint.position) <= 35f) {
                go.transform.LookAt(target);
            }
        }
        Bullet bullet = go.GetComponent<Bullet>();
        if (bullet) {
            bullet.Velocity = data.bulletSpeed;
            bullet.damages = Mathf.RoundToInt(CurrentDamages);
        }
    }

    public void Equip() {
        currentGraphics.SetActive(true);
    }

    public void Refill() {
        int refillAmount = MaxLoaderCapacity - LoaderAmount;

        if (BulletsAmount >= refillAmount) {
            LoaderAmount = MaxLoaderCapacity;
            BulletsAmount -= refillAmount;
        }
        else {
            LoaderAmount += BulletsAmount;
            BulletsAmount = 0;
        }
    }

    public void Unequip() {
        for (int i = 0; i < upgradeGraphics.Length; i++) {
            upgradeGraphics[i].SetActive(false);
        }
    }

    public void UpgradeWeapon() {
        upgradeLevel++;
        if (upgradeLevel < upgradeGraphics.Length) {
            currentGraphics = upgradeGraphics[upgradeLevel];
        }

        CurrentDamages = data.baseDamages * data.upgradeFactor;
    }

}
