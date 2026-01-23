using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<LevelData> levelList = new List<LevelData>();

    public LevelData currentLevel;
    private int currentLevelIndex = 0;

    public GameObject player;

    public BetterTransformingScript transformingScript;
    public BetterTransformUtilities transformUtilities;

    public Vector3 globalGravityScale;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DoorScript.OnLevelFinish += OnLevelFinish;

        SetupLevel();
        RestartLevel();

        Physics.gravity = globalGravityScale;
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

    public void RestartLevel()
    {
        float loadTime = 0.5f;
        Invoke("SetupLevel", loadTime);

        SceneManager.LoadScene("SampleScene");
    }

    private void SetupDoors()
    {
        DoorScript.unlockedDoorCount = 0;
        DoorScript.totalDoorsInLevel = currentLevel.doorCount;
    }

    private void SetupPlayer()
    {
        // UNCOMMENT TO REVERT TO OLD SYSTEM

        //player = GameObject.FindGameObjectWithTag("Player");

        //TransformerScript transformer = player.GetComponent<TransformerScript>();
        //transformer.TransformBackIntoGhostPig();
        SetupTransformReferencesWhenRestart();

        transformingScript.TransformBackIntoGhostPig();

        TeleportPlayerToNextLevel();
    }

    public void TeleportPlayerToNextLevel()
    {
        print("teleported the player");

        Vector3 spawnPosition = currentLevel.spawnLocation;

        print(currentLevel);

        GameObject body = transformUtilities.ghostBody;

        body.transform.position = spawnPosition;
    }

    private void SetupTransformReferencesWhenRestart()
    {
        if (transformUtilities == null || transformingScript == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            transformingScript = player.GetComponent<BetterTransformingScript>();
            transformUtilities = player.GetComponent<BetterTransformUtilities>();
        }
    }
}
