using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public LevelManager levelManager;

    private void Start()
    {
        HealthScript.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        HealthScript.OnDeath -= OnDeath;
    }

    private void OnDeath()
    {
        levelManager.RestartLevel();
    }
}
