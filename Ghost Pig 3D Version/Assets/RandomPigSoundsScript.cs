using UnityEngine;

public class RandomPigSoundsScript : MonoBehaviour
{
    public float startTime;
    public float repeatTime;

    public SFXPlayerScript sfxPlayer;

    private void Start()
    {
        InvokeRepeating("TryPlayingPigSounds", startTime, repeatTime);
    }


    private void TryPlayingPigSounds()
    {
        if (sfxPlayer.soundManager == null)
        {
            return; 
        }

        int randomValue = Random.Range(0, 2);

        if (randomValue == 0)
        {
            return;
        }

        AudioClip pigSquealSFX = sfxPlayer.soundManager.sfxStorage.pigSquealSFX;
        sfxPlayer.soundManager.PlayEffect(pigSquealSFX, true);
    }
}
