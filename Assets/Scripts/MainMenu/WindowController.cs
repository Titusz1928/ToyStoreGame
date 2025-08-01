using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WindowController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    public Slider musicVolumeSlider;
    public Toggle musicVolumeToggle;
    public Slider SFXVolumeSlider;
    public Toggle SFXVolumeToggle;

    private void Start()
    {
        musicVolumeSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        SFXVolumeSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
        if (AudioManager.Instance != null)
        {
            musicVolumeSlider.value = AudioManager.Instance.GetCurrentVolume();
            musicVolumeSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);

            musicVolumeToggle.onValueChanged.AddListener(isChecked => AudioManager.Instance.ToggleMusic(!isChecked));
            musicVolumeToggle.isOn = !AudioManager.Instance.IsMusicOn();

            SFXVolumeSlider.value = AudioManager.Instance.GetSFXVolume();
            SFXVolumeSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);

            SFXVolumeToggle.onValueChanged.AddListener(isChecked => AudioManager.Instance.ToggleSFX(!isChecked));
            SFXVolumeToggle.isOn = !AudioManager.Instance.IsSFXOn();

        }
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);

    }

    public void OpenMainMenuPanel()
    {
        settingsPanel.SetActive(false);
    }
}
