using UnityEngine;
using UnityEngine.UI;

public class SuspicionBarScript : MonoBehaviour
{
    public GameObject susBarObject;

    public Image suspicionBar;

    public HealthScript healthScript;

    public LevelManager levelManager;

    private void Start()
    {
        ChangeSuspicionBarFillAmount(healthScript.maxHealth);
        HealthScript.OnHealthChanged += OnHealthChanged;
        DoorScript.OnLevelFinish += OnLevelFinish;
    }

    private void OnDestroy()
    {
        HealthScript.OnHealthChanged -= OnHealthChanged;
        DoorScript.OnLevelFinish -= OnLevelFinish;

    }

    private void OnLevelFinish()
    {
        ChangeSuspicionBarFillAmount(healthScript.maxHealth);

    }

    private void OnHealthChanged(float health)
    {
        ChangeSuspicionBarFillAmount(health);
    }

    private void ChangeSuspicionBarFillAmount(float health)
    {
        float currentHealthBackwards = healthScript.maxHealth - health;
        print(currentHealthBackwards + "jpj");

        if (currentHealthBackwards == 0)
        {
            susBarObject.SetActive(false);
            return;
        }

        suspicionBar.fillAmount = currentHealthBackwards / healthScript.maxHealth;
        susBarObject.SetActive(true);
    }


}
