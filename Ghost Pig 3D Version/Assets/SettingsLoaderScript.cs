using UnityEngine;
using UnityEngine.UI;

public class SettingsLoaderScript : MonoBehaviour
{
    public Slider masterSlider, musicSlider, fxSlider;

    public Toggle fullScreenToggle;

    private void Start()
    {
        LoadSettingsValues();
    }

    private void LoadSettingsValues()
    {
        float defaultVolume = 0;

        float loadedMasterVolume = PlayerPrefs.GetFloat("MasterVolume", defaultVolume);
        masterSlider.value = loadedMasterVolume;

        float loadedMusicvolume = PlayerPrefs.GetFloat("MusicVolume", defaultVolume);
        musicSlider.value = loadedMusicvolume;

        float loadedFXVolume = PlayerPrefs.GetFloat("FXVolume", defaultVolume);
        fxSlider.value = loadedFXVolume;

        int defaultToggledIndex = 0;
        int toggledIndex = PlayerPrefs.GetInt("fullScreen", 0);
        bool toggledOn = toggledIndex == 1 ? true : false;
        fullScreenToggle.isOn = toggledOn;
    }
}
