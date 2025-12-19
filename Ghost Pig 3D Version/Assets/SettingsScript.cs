using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    private bool settingsOpened = false;
    public GameObject settingsPanel;

    public AudioMixer mainMixer;

    public void OpenCloseSettings()
    {
        if (settingsOpened)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }

        settingsOpened = !settingsOpened;
    }

    public void OnMasterVolumeChanged(float newVolume)
    {
        mainMixer.SetFloat("Master", newVolume);
        PlayerPrefs.SetFloat("MasterVolume", newVolume);
    }

    public void OnMusicVolumeChanged(float newVolume)
    {
        mainMixer.SetFloat("Music", newVolume);
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
    }

    public void OnFXVolumeChanged(float newVolume)
    {
        mainMixer.SetFloat("FX", newVolume);
        PlayerPrefs.SetFloat("FXVolume", newVolume);
    }

    public void OnFullScreenToggle(bool toggledOn)
    {
        Screen.fullScreen = toggledOn;

        int toggledIndex = toggledOn ? 1 : 0;
        PlayerPrefs.SetInt("fullScreen", toggledIndex);

        print(toggledOn);
    }
}
