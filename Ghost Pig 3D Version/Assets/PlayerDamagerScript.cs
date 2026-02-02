using UnityEngine;
using System;

public class PlayerDamagerScript : MonoBehaviour
{
    private bool DamagePlayer = false;

    private float timer = 0;
    private float time;

    private float damage;

    public HealthScript healthScript;

    private void Start()
    {
        SightZoneScript.OnSightEnter += OnSightEnter;
        SightZoneScript.OnSightExit += OnSightExit;
        DoorScript.OnLevelFinish += OnLevelFinish;
    }

    private void OnDestroy()
    {
        SightZoneScript.OnSightEnter -= OnSightEnter;
        SightZoneScript.OnSightExit -= OnSightExit;
    }

    private void Update()
    {
        DamagePlayerAccordingToTimer();

    }

    private void OnSightExit()
    {
        ActivateDamageEffect(false);
    }

    private void OnSightEnter(float damageAmount, float repeatTime)
    {
        ActivateDamageEffect(true, damageAmount, repeatTime);
    }

    public void OnLevelFinish()
    {
        float maxHealth = healthScript.maxHealth;
        ResetPlayerHealth(maxHealth);
    }

    private void DamagePlayerAccordingToTimer()
    {
        if (!DamagePlayer)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= time)
        {
            timer = 0;

            healthScript.TakeDamage(damage);
        }
    }

    private void ActivateDamageEffect(bool value, float damageAmount = -1, float repeatTime = -1)
    {
        if (!value)
        {
            print("Exited sight");
            DamagePlayer = false;
            return;
        }

        damage = damageAmount;
        time = repeatTime;

        print("Entered sight");
        DamagePlayer = true;
    }

    private void ResetPlayerHealth(float maxHealth)
    {
        healthScript.health = maxHealth;
    }
}
