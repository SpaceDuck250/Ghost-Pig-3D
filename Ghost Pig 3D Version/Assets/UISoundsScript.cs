using UnityEngine;
using System;

public class UISoundsScript : MonoBehaviour
{
    public static System.Action OnUIClick;
    public SoundManagerScript soundManager;
    public SfxStorerScript sfxStorerScript;

    private void Start()
    {
        OnUIClick += OnUIClickFunction;
    }

    private void OnDestroy()
    {
        OnUIClick -= OnUIClickFunction;

    }

    private void OnUIClickFunction()
    {
        AudioClip uiClickSFX = sfxStorerScript.uiClickSFX;
        soundManager.PlayEffect(uiClickSFX, true);
    }


}
