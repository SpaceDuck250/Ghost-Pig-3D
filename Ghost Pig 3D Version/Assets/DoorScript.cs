using UnityEngine;
using System;

public class DoorScript : MonoBehaviour
{
    public static int unlockedDoorCount;
    public static int totalDoorsInLevel;

    public static System.Action OnDoorUnlock;
    public static System.Action OnLevelFinish;

    public void IncrementDoorCount()
    {
        unlockedDoorCount++;
        if (unlockedDoorCount == totalDoorsInLevel)
        {
            print("finishedLevel");
            OnLevelFinish?.Invoke();
        }

    }
}
