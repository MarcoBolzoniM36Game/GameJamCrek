using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioExtension
{

    public static void SetSound(this GameObject go, AudioSource audioSource, Sound sound)
    {
        if (sound != null && audioSource != null && !audioSource.isPlaying)
        {
            audioSource.clip = sound.clip;
            audioSource.outputAudioMixerGroup = sound.outputAudioMixerGroup;
            audioSource.playOnAwake = sound.playOnAwake;
            audioSource.loop = sound.loop;
            audioSource.spatialBlend = sound.spatialBlend;
        }
    }

    public static void SetSoundAndPlay(this GameObject go, AudioSource audioSource, Sound sound)
    {
        if (sound != null && audioSource != null && !audioSource.isPlaying)
        {
            audioSource.clip = sound.clip;
            audioSource.outputAudioMixerGroup = sound.outputAudioMixerGroup;
            audioSource.playOnAwake = sound.playOnAwake;
            audioSource.loop = sound.loop;
            audioSource.spatialBlend = sound.spatialBlend;
            audioSource.Play();
        }
    }

    public static void PlaySound(this GameObject go, AudioSource audioSource)
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public static void MuteSound(this GameObject go, AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute;
        }
    }

    public static void StopSound(this GameObject go, AudioSource audioSource)
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
