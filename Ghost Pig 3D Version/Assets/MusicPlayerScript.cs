using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    private SongRandomizer randomizer;
    private SoundManagerScript soundManager; 

    private void Start()
    {
        if (DontDestroyScript.instance == null)
        {
            return;
        }

        randomizer = DontDestroyScript.instance.transform.Find("SoundManager").GetComponent<SongRandomizer>();

        soundManager = randomizer.soundManager;

        randomizer.PlayARandomSong();

        float startTime = 0;
        float waitTimeSeconds = 30;
        InvokeRepeating("CheckIfSongFinishedAndPlayNewSong", startTime, waitTimeSeconds);
    }

    private void CheckIfSongFinishedAndPlayNewSong()
    {
        if (soundManager.CheckIfSongFinished())
        {
            randomizer.PlayARandomSong();
        }
    }
}
