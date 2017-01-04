using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	public bool destroyOnDeath;

	const int maxHealth = 100;
	private int currentHealth = maxHealth;
	private RectTransform healthBar;
	
	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			if (destroyOnDeath)
				Destroy(gameObject);
			else
			{
				currentHealth = maxHealth;
				Respawn();
			}
		}
	}

	public void Respawn(){
		Vector3 spawnPoint = Vector3.zero;
		transform.position = spawnPoint;
	}
}
