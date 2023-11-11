using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    #region Singleton

    public static MenuUIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion


    public TMP_Dropdown resolutionDropDown;
    public TMP_Dropdown qualityDropDown;
    public TMP_Dropdown fullscreenModeDropDown;

    public void SetResolutions(List<string> resolutions, int currentResolutionIndex)
    {
        if (resolutionDropDown != null)
        {
            resolutionDropDown.ClearOptions();
            resolutionDropDown.AddOptions(resolutions);
            resolutionDropDown.value = currentResolutionIndex;
            resolutionDropDown.RefreshShownValue();
        }
    }

    public void SetGraphicsQuality(List<string> qualities, int currentQualityIndex)
    {
        if (qualityDropDown != null)
        {
            qualityDropDown.ClearOptions();
            qualityDropDown.AddOptions(qualities);
            qualityDropDown.value = currentQualityIndex;
            qualityDropDown.RefreshShownValue();
        }
    }

    public void SetFullscreenModes(List<string> modes, int currentFullscreenModeIndex)
    {
        if (fullscreenModeDropDown != null)
        {
            fullscreenModeDropDown.ClearOptions();
            fullscreenModeDropDown.AddOptions(modes);
            fullscreenModeDropDown.value = currentFullscreenModeIndex;
            fullscreenModeDropDown.RefreshShownValue();
        }
    }


    public GameObject IntroPanel;
    public GameObject MainMenuPanel;
    public GameObject PausePanel;

}
