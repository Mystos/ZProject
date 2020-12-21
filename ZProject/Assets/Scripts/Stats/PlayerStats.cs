using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public Stat maxHealth;          // Maximum amount of health
	public int CurrentHealth { get; protected set; }    // Current amount of health

	public Stat damage;
	public Stat armor;

	public event System.Action OnHealthReachedZero;

	public virtual void Awake()
	{
		CurrentHealth = maxHealth.GetValue();
	}

	
	public virtual void Start()
	{

	}

	// Damage the character
	public void TakeDamage(int damage)
	{

		int armorDamage = Mathf.Min(armor.GetValue(), damage);
		int healthDamage = Mathf.Min(CurrentHealth, damage - armorDamage);
		armor.AddModifier(-armorDamage);
		CurrentHealth -= healthDamage;
		Debug.Log(transform.name + " takes " + armorDamage + " armor damage and " + healthDamage + " health damage");

		// If we hit 0. Die.
		if (CurrentHealth <= 0)
		{
			if (OnHealthReachedZero != null)
			{
				OnHealthReachedZero();
			}
		}
	}

	// Heal the character.
	public void Heal(int amount)
	{
		CurrentHealth += amount;
		CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth.GetValue());
	}
}
