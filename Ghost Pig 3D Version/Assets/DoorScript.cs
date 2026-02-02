using UnityEngine;
using System;

public class DoorScript : MonoBehaviour
{
    public static int unlockedDoorCount;
    public static int totalDoorsInLevel;

    public static System.Action OnDoorUnlock;
    public static System.Action OnLevelFinish;

    public event System.Action OnSelfUnlocked;

    public void IncrementDoorCount()
    {
        unlockedDoorCount++;

        OnSelfUnlocked?.Invoke();
        OnDoorUnlock?.Invoke();
        if (unlockedDoorCount == totalDoorsInLevel)
        {
            print("finishedLevel");
            OnLevelFinish?.Invoke();
        }

    }
}
