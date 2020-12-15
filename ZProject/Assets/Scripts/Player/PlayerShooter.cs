using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] Transform weaponHolder;

    private FireWeapon[] weapons;
    private FireWeapon currentWeapon;
    private int weaponIndex = 0;

    private int weaponCount = 3;

    public bool isReloading = false;

    void Start()
    {
        weapons = new FireWeapon[weaponCount];
    }

    private void Update()
    {
        if (currentWeapon.LoaderAmount < currentWeapon.MaxLoaderCapacity)
        {
            if (Input.GetButtonDown("Reload"))
            {
                ReloadWeapon();
                return;
            }
        }

        if (currentWeapon.FireRate <= 0f)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                InvokeRepeating("Shoot", 0f, 1f / currentWeapon.FireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");
            }
        }

        if (Input.GetKeyDown("SwapWeapon"))
        {
            weaponIndex++;
            if (weaponIndex >= weaponCount)
                weaponIndex = 0;

            EquipWeapon(weapons[weaponIndex]);
        }
    }

    void Fire()
    {
        if (isReloading)
        {
            return;
        }

        if (currentWeapon.BulletsAmount <= 0)
        {
            ReloadWeapon();
            return;
        }
    }

    public void PickUpWeapon(FireWeapon weaponPrefab)
    {
        FireWeapon weapon = Instantiate(weaponPrefab, weaponHolder);
        EquipWeapon(weapon);
    }

    public void DropWeapon(FireWeapon weaponPrefab)
    {

    }

    public void EquipWeapon(FireWeapon weapon)
    {
        currentWeapon = weapon;
    }

    public void ReloadWeapon()
    {
        if (isReloading)
            return;

        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        Debug.Log("Reloading...");

        isReloading = true;

        //PlayReloadAnim()

        yield return new WaitForSeconds(currentWeapon.ReloadTime);

        currentWeapon.Refill();

        isReloading = false;
    }

    private void PlayReloadAnim()
    {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.SetTrigger("Reload");
        }
    }
}
