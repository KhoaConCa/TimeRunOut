using UnityEngine;

public interface IAudioHandler
{
    void SetMusicVolume(float volume);
    void SetSFXVolume(float volume);
    void LoadVolume();
    void PlayDeathSound();
}

