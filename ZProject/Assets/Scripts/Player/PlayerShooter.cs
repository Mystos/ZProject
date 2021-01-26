using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour {
    [SerializeField] Transform weaponHolder;
    [SerializeField] int weaponCount = 2;

    public GameObject reloadingDisplay;

    public FireWeapon CurrentWeapon { get; private set; }
    private FireWeapon[] weapons;
    private int weaponIndex = 0;


    public bool isReloading = false;

    void Start() {
        weapons = new FireWeapon[weaponCount];
    }

    private void Update() {
        if (CurrentWeapon != null) {
            if (CurrentWeapon.LoaderAmount < CurrentWeapon.MaxLoaderCapacity) {
                if (Input.GetButtonDown("Reload")) {
                    ReloadWeapon();
                    return;
                }
            }

            if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) {
                Fire();
            }
        }

        if (Input.GetButtonDown("SwapWeapons")) {
            weaponIndex++;
            if (weaponIndex >= weaponCount)
                weaponIndex = 0;

            EquipWeapon(weaponIndex);
        }
    }

    void Fire() {
        if (isReloading) {
            return;
        }

        if (CurrentWeapon.LoaderAmount <= 0) {
            ReloadWeapon();
            return;
        }

        CurrentWeapon.Fire();
    }

    public void PickUpWeapon(FireWeapon weaponPrefab) {
        if (weapons[weaponIndex] != null) {
            Destroy(weapons[weaponIndex].gameObject);
        }

        FireWeapon newWeapon = Instantiate(weaponPrefab, weaponHolder);
        newWeapon.Init();
        weapons[weaponIndex] = newWeapon;
        EquipWeapon(weaponIndex);
    }

    public void EquipWeapon(int index) {
        CurrentWeapon = weapons[index];
        for (int i = 0; i < weapons.Length; i++) {
            if (weapons[i] != null)
                weapons[i].Unequip();
        }
        if (CurrentWeapon != null)
            CurrentWeapon.Equip();
    }

    public void ReloadWeapon() {
        if (isReloading)
            return;

        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine() {
        Debug.Log("Reloading...");

        isReloading = true;

        //PlayReloadAnim()
        reloadingDisplay.SetActive(true);
        AudioManager.instance.Play("Reload");

        yield return new WaitForSeconds(CurrentWeapon.ReloadTime);

        CurrentWeapon.Refill();
        reloadingDisplay.SetActive(false);

        isReloading = false;
    }

    private void PlayReloadAnim() {
        Animator anim = GetComponent<Animator>();
        if (anim != null) {
            anim.SetTrigger("Reload");
        }
    }
}
