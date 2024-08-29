using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioH : MonoBehaviour, IAudioHandler
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
    private AudioMixer mixer;
    private Slider musicSlider;
    private Slider SFXSlider;
    private AudioClip deathSound;
    //[SerializeField] private AudioClip deathSound;
    //[SerializeField] private AudioC audioCommand;
    #endregion

    #region Methods
    /*    public void PlaySFX(AudioClip clip)
        {
            audioCommand.SFXsource.PlayOneShot(clip);
        }*/

    #region Constructor
    public AudioH(AudioMixer mixer, Slider musicSlider, Slider SFXSlider)
    {
        this.mixer = mixer;
        this.musicSlider = musicSlider;
        this.SFXSlider = SFXSlider;
    }
    #endregion

    #region Music
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume(musicSlider.value);
        SetSFXVolume(SFXSlider.value);
    }
    #endregion

    #region SFX
    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    #endregion

    #region Die
    public void PlayDeathSound()
    {
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, Vector3.zero);
        }
    }
    #endregion

    #endregion
}
