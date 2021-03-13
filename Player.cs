using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float maxHealth = 100f;
	public float currentHealth;

	public HealthBar healthBar;

    // Start is called before the first frame update
    public void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    public void Update()
    {
		if (Input.GetKeyDown(KeyCode.P))
		{
			TakeDamage(3f);
		}
    }

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}