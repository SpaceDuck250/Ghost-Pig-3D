using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;
using System.Collections;

public class SongRandomizer : MonoBehaviour
{
    public List<AudioClip> songList = new List<AudioClip>();
    public SoundManagerScript soundManager;

    public void PlayARandomSong()
    {
        AudioClip randomSong = PickRandomSong();
        soundManager.PlayMusic(randomSong, false);
    }

    public AudioClip PickRandomSong()
    {
        int randomValue = Random.Range(0, songList.Count);

        AudioClip pickedSong = songList[randomValue];

        return pickedSong;
    }

}
