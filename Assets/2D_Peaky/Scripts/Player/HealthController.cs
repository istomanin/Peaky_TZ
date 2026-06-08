using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{


    [SerializeField] private int maxHealth = 10;
    [SerializeField] private GameOverUI GameOverUI;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameOverUI.ShowGameOver();
    }
}
