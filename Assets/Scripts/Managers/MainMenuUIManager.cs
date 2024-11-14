using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField]
    Slider musicSlider;
    [SerializeField]
    Button musicMuteButton;

    [Header("SFX")]
    [SerializeField]
    Slider sfxSlider;
    [SerializeField]
    Button sfxMuteButton;

    [Header("Mute Button")]
    [SerializeField]
    Sprite muteButton;
    [SerializeField]
    Sprite unmuteButton;

    [Header("Settings")]
    [SerializeField]
    GameObject settingsPanel;
    [SerializeField]
    Button settingsButton;
    [SerializeField]
    Button settingsCloseButton;

    [Header("PlayButton")]
    [SerializeField]
    Button playButton;

    private void Start()
    {
        AudioManager.instance.PlayMusic("MainMenu");

        playButton.onClick.AddListener(StartGame);

        settingsButton.onClick.AddListener(ToggleSettingsPanel);
        settingsCloseButton.onClick.AddListener(ToggleSettingsPanel);

        musicMuteButton.onClick.AddListener(ToggleMusicMute);
        sfxMuteButton.onClick.AddListener(ToggleSFXMute);
    }

    public void StartGame()
    {
        AudioManager.instance.PlaySFX("ButtonClick");
        AudioManager.instance.StopMusic();

        SceneManager.LoadScene(DifficultyManager.instance.difficultySelected.ToString());
    }

    void ToggleSettingsPanel()
    {
        AudioManager.instance.PlaySFX("ButtonClick");
        settingsPanel.SetActive(!settingsPanel.activeSelf);
        settingsButton.gameObject.SetActive(!settingsPanel.activeSelf);
    }

    void ToggleMusicMute()
    {
        AudioManager.instance.ToggleMusic();
        ChangeMuteButtonIcon(AudioManager.instance.musicSource, musicMuteButton.GetComponent<Image>());
    }

    void ToggleSFXMute()
    {
        AudioManager.instance.ToggleSFX();
        ChangeMuteButtonIcon(AudioManager.instance.sfxSource, sfxMuteButton.GetComponent<Image>());
    }

    public void ChangeMuteButtonIcon(AudioSource _audioSource, Image buttonImage)
    {
        if(_audioSource.mute == true)
        {
            buttonImage.sprite = muteButton;
            return;
        }

        buttonImage.sprite = unmuteButton;
    }

    public void AdjustMusicVolume()
    {
        AudioManager.instance.UpdateMusicVolume(musicSlider.value);
    }

    public void AdjustSFXVolume()
    {
        AudioManager.instance.UpdateSFXVolume(sfxSlider.value);
    }
}
