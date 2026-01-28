using UnityEngine;

public class GameInitializerScript : MonoBehaviour
{
    public LevelManager levelManager;

    private void Start()
    {
        levelManager = LevelManager.instance;


        //levelManager.RestartLevel();

    }


}
