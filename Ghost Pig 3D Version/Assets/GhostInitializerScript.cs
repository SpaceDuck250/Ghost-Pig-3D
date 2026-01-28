using UnityEngine;

public class GhostInitializerScript : MonoBehaviour
{
    private void Start()
    {
        float waitTime = 0.2f;
        Invoke("TeleportToFirstLevel", waitTime);
    }

    public void TeleportToFirstLevel()
    {
        int currentLevelIndex = LevelManager.instance.currentLevelIndex;
        transform.position = LevelManager.instance.levelList[currentLevelIndex].spawnLocation;
    }
}
