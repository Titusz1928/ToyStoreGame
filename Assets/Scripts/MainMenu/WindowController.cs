using System.Collections;
using System.Collections.Generic;
using Tabmenu.UI;
using UnityEngine;
using UnityEngine.UI;


public class WindowController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject newGamePanel;

    public Slider musicVolumeSlider;
    public Toggle musicVolumeToggle;

    public Slider SFXVolumeSlider;
    public Toggle SFXVolumeToggle;

    public Slider gameAreaSlider;
    public Slider cardNumberSlider;

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

        gameAreaSlider.onValueChanged.AddListener(NewGameManager.Instance.SetGameArea);
        cardNumberSlider.onValueChanged.AddListener(NewGameManager.Instance.SetCardNumber);

    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
        newGamePanel.SetActive(false);

    }

    public void OpenNewGamePanel()
    {
        settingsPanel.SetActive(false);
        newGamePanel.SetActive(true);

        GameSettings.GridWidth = Mathf.RoundToInt(7);
        GameSettings.GridHeight = Mathf.RoundToInt(5);

        // Force tab index 0 to be active
        var tabMenu = newGamePanel.GetComponentInChildren<TabMenu>();
        if (tabMenu != null)
        {
            tabMenu.JumpToPage(0);
        }
    }

    public void OpenMainMenuPanel()
    {
        settingsPanel.SetActive(false);
        newGamePanel.SetActive(false);
    }
}
