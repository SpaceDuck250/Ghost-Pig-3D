using UnityEngine;
using System;

public class HealthScript : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public static event Action<float> OnHealthChanged;

    public static event System.Action OnDeath;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;

            OnDeath?.Invoke();
        }

        OnHealthChanged?.Invoke(health);
        print(health);
    }

   

    


}
