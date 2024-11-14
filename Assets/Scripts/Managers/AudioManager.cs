using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    public void PlayMusic(string name)
    {
        Sound music = Array.Find(musicSounds, x => x.name == name);

        if (music == null)
        {
          Debug.Log("Sound Not Found");  
            return;
        }

        musicSource.clip = music.clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(string name)
    {
        Sound sfx = Array.Find(sfxSounds, x => x.name == name);

        if (sfx == null)
        {
          Debug.Log("Sound Not Found");  
            return;
        }

        sfxSource.PlayOneShot(sfx.clip);
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void UpdateMusicVolume(float _volume)
    {
        musicSource.volume = _volume;
    }

    public void UpdateSFXVolume(float _volume)
    {
        sfxSource.volume = _volume;
    }
}
