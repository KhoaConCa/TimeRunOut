using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioH : MonoBehaviour
{
    #region Fields
    /*    [SerializeField] private AudioSource musicSource;
    [SerializeField] public AudioSource SFXsource;

    public AudioClip background;
    public AudioClip death;
    public AudioClip checkpoint;
    public AudioClip wallTouch;
    public AudioClip portalIn;
    public AudioClip portalOut;*/
    [SerializeField] private AudioClip deathSound;
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
        audioCommand.mixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void LoadVolume()
    {
        audioCommand.musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        audioCommand.SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
    #endregion

    #region SFX
    public void SetSFXVolume()
    {
        float volume = audioCommand.SFXSlider.value;
        audioCommand.mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    #endregion

    #region Die
    public void PlayDeathSound()
    {
        if (deathSound != null)
        {
            audioCommand.mixer.SetFloat("SFX", Mathf.Log10(audioCommand.SFXSlider.value) * 20);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
    }
    #endregion

    #endregion
}