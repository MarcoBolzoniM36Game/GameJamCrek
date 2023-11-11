using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    #region SINGLETON

    public static AudioManager Instance;

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

    [SerializeField]
    private AudioMixer audioMixer;

    public List<Sound> Sounds = new List<Sound>();

    [SerializeField]
    private Slider masterSlider;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider voiceSlider;

    [SerializeField]
    private Slider ambientSlider;

    [SerializeField]
    private Slider vfxSlider;

    public const string MIXER_MASTERVOLUME_KEY = "MasterVolume";
    public const string MIXER_MUSICVOLUME_KEY = "MusicVolume";
    public const string MIXER_VOICEVOLUME_KEY = "VoiceVolume";
    public const string MIXER_AMBIENTVOLUME_KEY = "AmbientVolume";
    public const string MIXER_VFXVOLUME_KEY = "VFXVolume";

    public const string MASTERVOLUME_PREFS_KEY = "MasterVolumePrefsKey";
    public const string MUSICVOLUME_PREFS_KEY = "MusicVolumePrefsKey";
    public const string VOICEVOLUME_PREFS_KEY = "VoiceVolumePrefsKey";
    public const string AMBIENTVOLUME_PREFS_KEY = "AmbientVolumePrefsKey";
    public const string VFXVOLUME_PREFS_KEY = "VxfVolumePrefsKey";

    private void OnEnable()
    {
        masterSlider.value = PlayerPrefs.GetFloat(MASTERVOLUME_PREFS_KEY, 1f);
        musicSlider.value = PlayerPrefs.GetFloat(MUSICVOLUME_PREFS_KEY, 1f);
        voiceSlider.value = PlayerPrefs.GetFloat(VOICEVOLUME_PREFS_KEY, 1f);
        ambientSlider.value = PlayerPrefs.GetFloat(AMBIENTVOLUME_PREFS_KEY, 1f);
        vfxSlider.value = PlayerPrefs.GetFloat(VFXVOLUME_PREFS_KEY, 1f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(MASTERVOLUME_PREFS_KEY, masterSlider.value);
        PlayerPrefs.SetFloat(MUSICVOLUME_PREFS_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(VOICEVOLUME_PREFS_KEY, voiceSlider.value);
        PlayerPrefs.SetFloat(AMBIENTVOLUME_PREFS_KEY, ambientSlider.value);
        PlayerPrefs.SetFloat(VFXVOLUME_PREFS_KEY, vfxSlider.value);
    }

    /// <summary>
    /// Imposta il master volume nel mixer,
    /// da usare nel changeValue dello slider
    /// </summary>
    /// <param name="sliderValue">Valore dello slider da 0 a 1</param>
    public void SetMasterVolume(float sliderValue)
    {
        audioMixer?.SetFloat(MIXER_MASTERVOLUME_KEY, Mathf.Log10(sliderValue) * 20.0f);
    }

    /// <summary>
    /// Imposta il music volume nel mixer,
    /// da usare nel changeValue dello slider
    /// </summary>
    /// <param name="sliderValue">Valore dello slider da 0 a 1</param>
    public void SetMusicVolume(float sliderValue)
    {
        audioMixer?.SetFloat(MIXER_MUSICVOLUME_KEY, Mathf.Log10(sliderValue) * 20.0f);
    }

    public void SetVoiceVolume(float sliderValue)
    {
        audioMixer?.SetFloat(MIXER_VOICEVOLUME_KEY, Mathf.Log10(sliderValue) * 20.0f);
    }

    public void SetAmbientVolume(float sliderValue)
    {
        audioMixer?.SetFloat(MIXER_AMBIENTVOLUME_KEY, Mathf.Log10(sliderValue) * 20.0f);
    }

    public void SetVFXVolume(float sliderValue)
    {
        audioMixer?.SetFloat(MIXER_VFXVOLUME_KEY, Mathf.Log10(sliderValue) * 20.0f);
    }
}
