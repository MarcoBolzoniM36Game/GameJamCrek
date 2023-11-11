using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance { get; private set; }

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

    public const string INTRO_SCENE_NAME = "IntroScene";
    public const string MAINMENU_SCENE_NAME = "MainMenuScene";
    public const string GAME_SCENE_NAME = "GameScene";

    #region Menu

    public void SkipIntro()
    {
        if (menuUIManager != null)
        {
            menuUIManager.MainMenuPanel.SetActive(true);
            menuUIManager.IntroPanel.SetActive(false);
            SceneManager.LoadScene(MAINMENU_SCENE_NAME);
        }
    }

    public void ViewIntro()
    {
        if (menuUIManager != null)
        {
            menuUIManager.IntroPanel.SetActive(true);
            menuUIManager.MainMenuPanel.SetActive(false);
            SceneManager.LoadScene(INTRO_SCENE_NAME);
        }
    }

    public void StartGame()
    {
        if (menuUIManager != null)
        {
            menuUIManager.MainMenuPanel.SetActive(false);
            SceneManager.LoadScene(GAME_SCENE_NAME);
        }
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void PauseGame()
    {
        if (menuUIManager != null)
        {
            menuUIManager.PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    public void ResumeGame()
    {
        Debug.Log("RESUMEEE!!");
        if (menuUIManager != null)
        {
            menuUIManager.PausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("ReturnToMainMenu!!");
        SceneManager.LoadScene(MAINMENU_SCENE_NAME);
    }

    #region Video Menu

    private Resolution[] resolutions;
    private FullScreenMode[] fullScreenModes;

    public MenuUIManager menuUIManager;

    public const string RESOLUTION_KEY = "ResolutionKey";
    public const string QUALITY_LEVEL_KEY = "QualityLevelKey";
    public const string FULLSCREENMODE_KEY = "FullscreenModeKey";

    private void LoadResolutionOptions()
    {
        if (menuUIManager != null)
        {
            int currentResolutionIndex = 0;
            Resolution currentResolution = Screen.currentResolution;
            resolutions = Screen.resolutions;
            List<string> list = new List<string>();
            for (int i = 0; i < resolutions.Length; i++)
            {
                Resolution res = resolutions[i];
                StringBuilder sb = new StringBuilder();
                sb.Append(res.width).Append(" x ").Append(res.height).Append(" x ").Append(res.refreshRateRatio.value).Append("Hz");
                list.Add(sb.ToString());
                if (res.width == currentResolution.width &&
                    res.height == currentResolution.height &&
                    res.refreshRateRatio.value == currentResolution.refreshRateRatio.value
                    )
                {
                    currentResolutionIndex = i;
                }
            }
            if (PlayerPrefs.HasKey(RESOLUTION_KEY))
            {
                currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_KEY);
            }
            menuUIManager.SetResolutions(list, currentResolutionIndex);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        //FullScreenMode fsMode = 
        Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.ExclusiveFullScreen, resolution.refreshRateRatio);
        PlayerPrefs.SetInt(RESOLUTION_KEY, resolutionIndex);
    }



    private void LoadQualityOptions()
    {
        if (menuUIManager != null)
        {
            int currentQualityIndex = QualitySettings.GetQualityLevel();
            if (PlayerPrefs.HasKey(QUALITY_LEVEL_KEY))
            {
                currentQualityIndex = PlayerPrefs.GetInt(QUALITY_LEVEL_KEY);
                QualitySettings.SetQualityLevel(currentQualityIndex);
            }
            List<string> list = QualitySettings.names.ToList();
            menuUIManager.SetGraphicsQuality(list, currentQualityIndex);
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt(QUALITY_LEVEL_KEY, qualityIndex);
    }



    public void LoadFullscreenModeOptions()
    {
        if (menuUIManager != null)
        {
            int currentFullscreeModeIndex = 0;
            FullScreenMode currentFullscreenMode = Screen.fullScreenMode;
            fullScreenModes = PopulateFullscreenModes();
            List<string> list = new List<string>();
            for (int i = 0; i < fullScreenModes.Length; i++)
            {
                FullScreenMode mode = fullScreenModes[i];
                list.Add(mode.ToString());
                if (mode.Equals(currentFullscreenMode))
                {
                    currentFullscreeModeIndex = i;
                }
            }
            if (PlayerPrefs.HasKey(FULLSCREENMODE_KEY))
            {
                currentFullscreeModeIndex = PlayerPrefs.GetInt(FULLSCREENMODE_KEY);
            }
            menuUIManager.SetFullscreenModes(list, currentFullscreeModeIndex);
        }
    }

    private FullScreenMode[] PopulateFullscreenModes()
    {
        FullScreenMode[] modes = null;
        if (Application.platform == RuntimePlatform.WindowsPlayer
            || Application.platform == RuntimePlatform.WindowsEditor
            || Application.platform == RuntimePlatform.WindowsServer
            )
        {
            modes = new FullScreenMode[2];
            modes[0] = FullScreenMode.ExclusiveFullScreen;
            modes[1] = FullScreenMode.Windowed;
        }
        else if (Application.platform == RuntimePlatform.OSXPlayer
            || Application.platform == RuntimePlatform.OSXEditor
            || Application.platform == RuntimePlatform.OSXServer
            )
        {
            modes = new FullScreenMode[2];
            modes[0] = FullScreenMode.MaximizedWindow;
            modes[1] = FullScreenMode.Windowed;
        }
        else
        {
            modes = new FullScreenMode[2];
            modes[0] = FullScreenMode.FullScreenWindow;
            modes[1] = FullScreenMode.Windowed;
        }
        //// TODO: da cambiare in funzione della piattaforma su cui verra eseguito
        //if (Application.platform == RuntimePlatform.WindowsPlayer)
        //{
        //    modes = new FullScreenMode[3];
        //    modes[0] = FullScreenMode.ExclusiveFullScreen;
        //    modes[1] = FullScreenMode.FullScreenWindow;
        //    modes[2] = FullScreenMode.MaximizedWindow;
        //    modes[2] = FullScreenMode.Windowed;
        //}
        return modes;
    }

    public void SetFullscreen(int fullscreenModeIndex)
    {
        Screen.fullScreenMode = fullScreenModes[fullscreenModeIndex];
        PlayerPrefs.SetInt(FULLSCREENMODE_KEY, fullscreenModeIndex);
    }

    #endregion

    #endregion

    private void Start()
    {
        LoadResolutionOptions();
        LoadFullscreenModeOptions();
        LoadQualityOptions();
    }

}
