using UnityEngine;
using System.Collections.Generic;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<LevelData> levelList = new List<LevelData>();

    public LevelData currentLevel;
    private int currentLevelIndex = 0;

    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DoorScript.OnLevelFinish += OnLevelFinish;

        SetupLevel();
    }

    private void OnDestroy()
    {
        DoorScript.OnLevelFinish -= OnLevelFinish;
    }

    private void OnLevelFinish()
    {
        IncrementLevel();
        SetupLevel();
    }

    private void IncrementLevel()
    {
        int maxLevelIndex = levelList.Count - 1;
        if (currentLevelIndex >= maxLevelIndex)
        {
            return;
        }

        currentLevelIndex++;
        currentLevel = levelList[currentLevelIndex];
    }

    private void SetupLevel()
    {
        SetupDoors();
        SetupPlayer();
    }

    private void SetupDoors()
    {
        DoorScript.unlockedDoorCount = 0;
        DoorScript.totalDoorsInLevel = currentLevel.doorCount;
    }

    private void SetupPlayer()
    {
        TransformerScript transformer = player.GetComponent<TransformerScript>();
        transformer.TransformBackIntoGhostPig();

        TeleportPlayerToNextLevel();
    }

    private void TeleportPlayerToNextLevel()
    {
        Vector3 spawnPosition = currentLevel.spawnLocation;

        player.transform.position = spawnPosition;
    }
}
