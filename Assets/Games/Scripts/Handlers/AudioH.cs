using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioH : MonoBehaviour
{
    #region Fields
    [SerializeField] private AudioC audioCommand;
    #endregion

    #region Methods
    /*    public void PlaySFX(AudioClip clip)
        {
            audioCommand.SFXsource.PlayOneShot(clip);
        }*/
    #region Music
    public void SetMusicVolume()
    {
        float volume = audioCommand.musicSlider.value;
        audioCommand.mixer.SetFloat("music",  Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void LoadVolume()
    {
        audioCommand.musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        audioCommand.SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
    }
    #endregion

    #region SFX
    public void SetSFXVolume()
    {
        float volume = audioCommand.musicSlider.value;
        audioCommand.mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    #endregion

    #endregion
}
