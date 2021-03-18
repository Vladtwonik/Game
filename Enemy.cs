using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float maxHealth = 100f;
	public float currentHealth;
	public HealthBar healthBar;


    public void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0){
            Die();
        }
	}

    void Die(){
        Debug.Log("Enemy died!");
    }
}
