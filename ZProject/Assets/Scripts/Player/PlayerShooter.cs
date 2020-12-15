using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] Transform weaponHolder;
    [SerializeField] int weaponCount = 2;

    public FireWeapon CurrentWeapon { get; private set; }
    private FireWeapon[] weapons;
    private int weaponIndex = 0;


    public bool isReloading = false;

    void Start()
    {
        weapons = new FireWeapon[weaponCount];
    }

    private void Update()
    {
        if (CurrentWeapon != null)
        {
            if (CurrentWeapon.LoaderAmount < CurrentWeapon.MaxLoaderCapacity)
            {
                if (Input.GetButtonDown("Reload"))
                {
                    ReloadWeapon();
                    return;
                }
            }

            if (CurrentWeapon.FireRate <= 0f)
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
                    InvokeRepeating("Fire", 0f, 1f / CurrentWeapon.FireRate);
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    CancelInvoke("Fire");
                }
            }
        }

        if (Input.GetButtonDown("SwapWeapons"))
        {
            weaponIndex++;
            if (weaponIndex >= weaponCount)
                weaponIndex = 0;

            EquipWeapon(weaponIndex);
        }
    }

    void Fire()
    {
        if (isReloading)
        {
            return;
        }

        if (CurrentWeapon.LoaderAmount <= 0)
        {
            ReloadWeapon();
            return;
        }

        CurrentWeapon.Fire();
    }

    public void PickUpWeapon(FireWeapon weaponPrefab)
    {
        if (weapons[weaponIndex] != null)
        {
            Destroy(weapons[weaponIndex].gameObject);
        }

        FireWeapon newWeapon = Instantiate(weaponPrefab, weaponHolder);
        newWeapon.Init();
        weapons[weaponIndex] = newWeapon;
        EquipWeapon(weaponIndex);
    }

    public void EquipWeapon(int index)
    {
        CurrentWeapon = weapons[index];
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null)
                weapons[i].Unequip();
        }
        if (CurrentWeapon != null)
            CurrentWeapon.Equip();
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

        yield return new WaitForSeconds(CurrentWeapon.ReloadTime);

        CurrentWeapon.Refill();

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
