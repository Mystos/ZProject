using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	FireWeaponData data;
    public float damage;
    public int loaderData;
    public int maxBullets;
    public int bullets;
    public float fireRate;
    public float range;
    public float reloadTime;
    public GameObject graphics;

    public PlayerWeapon()
	{
		data.loaderCapacity = data.loaderMaxCapacity;

	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
