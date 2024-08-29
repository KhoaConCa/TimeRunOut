using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioC : MonoBehaviour
{
    #region Fields
    [SerializeField] public AudioMixer mixer;
    [SerializeField] public Slider musicSlider;
    [SerializeField] public Slider SFXSlider;
    [SerializeField] public AudioH audioHandler;
    #endregion

    #region Methods
    private void Start()
    {
        /*musicSource.clip = background;
        musicSource.Play();*/
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            audioHandler.LoadVolume();
        }
        else
        {
            audioHandler.SetMusicVolume();
            audioHandler.SetSFXVolume();
        }
    }
    #endregion
}