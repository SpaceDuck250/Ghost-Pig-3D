using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource musicSrc, fxSrc;

    public AudioClip musicClip, fxClip;

    private void Start()
    {
        musicSrc.clip = musicClip;
        musicSrc.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            fxSrc.PlayOneShot(fxClip);
        }
    }
}
