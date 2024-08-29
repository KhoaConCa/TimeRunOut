using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioC : MonoBehaviour
{
    #region Fields
    [SerializeField] public AudioMixer mixer;
    [SerializeField] public Slider musicSlider;
    [SerializeField] public Slider SFXSlider;
    private IAudioHandler audioHandler;
    #endregion

    #region Methods
    private void Start()
    {
        /*musicSource.clip = background;
        musicSource.Play();*/
        audioHandler = new AudioH(mixer, musicSlider, SFXSlider);

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            audioHandler.LoadVolume();
        }
        else
        {
            audioHandler.SetMusicVolume(musicSlider.value);
            audioHandler.SetSFXVolume(SFXSlider.value);
        }
    }
    #endregion
}
