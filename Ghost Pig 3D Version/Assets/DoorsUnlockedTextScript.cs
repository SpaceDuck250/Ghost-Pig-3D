using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorsUnlockedTextScript : MonoBehaviour
{
    public TextMeshProUGUI doorUnlockedTextComponent;

    public string doorUnlockedString;

    private void Start()
    {
        DoorScript.OnDoorUnlock += OnDoorUnlock;
        DoorScript.OnLevelFinish += OnLevelFinish;
    }

    private void OnDestroy()
    {
        DoorScript.OnDoorUnlock -= OnDoorUnlock;
        DoorScript.OnLevelFinish -= OnLevelFinish;
    }

    public void OnDoorUnlock()
    {
        float doorsUnlocked = DoorScript.unlockedDoorCount;
        float doorsTotal = DoorScript.totalDoorsInLevel;

        string doorsUnlockedText = doorUnlockedString + doorsUnlocked + "/" + doorsTotal;
        doorUnlockedTextComponent.text = doorsUnlockedText;
    }

    public void OnLevelFinish()
    {
        doorUnlockedTextComponent.text = string.Empty;
    }
}
