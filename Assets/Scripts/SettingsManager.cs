using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown graphicsDropdown;
    public Dropdown resolutionDropdown;
    public Dropdown musicDropdown;
    public Dropdown effectsDropdown;
    public Button mainMenuButton;
    public Button applyButton;

    public Resolution[] resolutions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        graphicsDropdown.onValueChanged.AddListener(delegate { OnGraphicsChange(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        musicDropdown.onValueChanged.AddListener(delegate { OnMusicChange(); });
        effectsDropdown.onValueChanged.AddListener(delegate { OnEffectsChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });
        mainMenuButton.onClick.AddListener(delegate { OnMainMenuButtonClick(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void OnFullScreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
        Debug.Log("Fullscreen?");
    }

    public void OnGraphicsChange()
    {
        gameSettings.graphics = gameSettings.graphics = graphicsDropdown.value;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolution = resolutionDropdown.value;
    }

    public void OnMusicChange()
    {
        gameSettings.music = gameSettings.music = musicDropdown.value;
    }

    public void OnEffectsChange()
    {
        gameSettings.effects = gameSettings.effects = effectsDropdown.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(Application.persistentDataPath + "/gamesettings.json");

        effectsDropdown.value = gameSettings.effects;
        musicDropdown.value = gameSettings.music;
        graphicsDropdown.value = gameSettings.graphics;
        resolutionDropdown.value = gameSettings.resolution;
        fullscreenToggle.isOn = gameSettings.fullscreen;
        Screen.fullScreen = gameSettings.fullscreen;

        resolutionDropdown.RefreshShownValue();
    }
}
