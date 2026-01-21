using UnityEngine;
using System.Collections.Generic;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource musicSrc, fxSrc, footstepSrc;

    public AudioClip mainMenuMusicClip;

    public SfxStorerScript sfxStorage;

    private void Start()
    {
        PlayMusic(mainMenuMusicClip, true);
    }

    private void Update()
    {
    }

    public void PlayMusic(AudioClip musicClip, bool looped)
    {
        musicSrc.Stop();
        musicSrc.clip = musicClip;

        musicSrc.loop = looped;

        musicSrc.Play();
    }

    public void PlayEffect(AudioClip audioClip, bool oneShot)
    {
        if (oneShot)
        {
            fxSrc.PlayOneShot(audioClip);
        }
        else
        {
            fxSrc.clip = audioClip;
            fxSrc.Play();
        }
    }

    public void StopAllMusic()
    {
        musicSrc.Stop();
        footstepSrc.Stop();
    }

    public bool CheckIfSongFinished()
    {
        if (!musicSrc.isPlaying && musicSrc.clip != null)
        {
            return true;
        }

        return false;
    }

    public void PlayFootsteps(bool play)
    {
        if (footstepSrc.clip == null && play)
        {
            footstepSrc.clip = sfxStorage.footstepSFX;
            footstepSrc.loop = true;

            footstepSrc.Play();
        }

        if (play)
        {
            footstepSrc.UnPause();
        }
        else
        {
            footstepSrc.Pause();
        }
    }
}
