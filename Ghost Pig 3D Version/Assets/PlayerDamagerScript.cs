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
        print("Exited sight");
        DamagePlayer = false;
    }

    private void OnSightEnter(float damageAmount, float repeatTime)
    {
        damage = damageAmount;
        time = repeatTime;

        print("Entered sight");
        DamagePlayer = true;
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
}
