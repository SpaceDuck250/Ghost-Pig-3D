using UnityEngine;

public class LevelFinisher : MonoBehaviour
{
    private SoundManagerScript soundManager;

    private void Start()
    {
        if (DontDestroyScript.instance == null)
        {
            return;
        }

        soundManager = DontDestroyScript.instance.transform.Find("SoundManager").GetComponent<SoundManagerScript>();

        DoorScript.OnLevelFinish += OnLevelFinish;
    }

    private void OnDestroy()
    {
        DoorScript.OnLevelFinish -= OnLevelFinish;
    }

    private void OnLevelFinish()
    {
        soundManager.PlayFootsteps(false);
    }
}
