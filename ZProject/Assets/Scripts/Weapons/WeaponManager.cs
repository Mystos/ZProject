using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private Transform weaponHolder;

    private FireWeapon currentWeapon;
    private FireWeapon[] weapons;

    public bool isReloading = false;

    void Start()
    {
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


    void EquipWeapon(FireWeapon weapon)
    {
        currentWeapon = weapon;
    }

    void PickWeapon()
    {

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
