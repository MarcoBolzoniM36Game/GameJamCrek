using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    /// <summary>
    /// Nome della clip
    /// </summary>
    public string name;

    /// <summary>
    /// Clip da riprodurre
    /// </summary>
    public AudioClip clip;

    /// <summary>
    /// Gruppo dell'audio mixer che riprodurrà la clip
    /// </summary>
    public AudioMixerGroup outputAudioMixerGroup;

    /// <summary>
    /// Indica se mutare la riproduzione della clip
    /// </summary>
    public bool mute;

    /// <summary>
    /// Indica se la clip va suonata durante l'Awake
    /// </summary>
    public bool playOnAwake;

    /// <summary>
    /// Indica se la clip va suonata ciclicamente
    /// </summary>
    public bool loop;

    /// <summary>
    /// Indica se il suono deve essere trattato come 2d o 3d o intermedio
    /// </summary>
    [Range(0f, 1f)]
    public float spatialBlend;
}
