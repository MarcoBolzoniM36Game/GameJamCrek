using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TestAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private void OnValidate()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Start()
    {
        //Sound sound = AudioManager.Instance.Sounds.FirstOrDefault(o => o.name == AudioClipName);
        //gameObject.SetSound(audioSource, sound);
        //gameObject.PlaySound(audioSource);
    }

    public void Play(string clipName)
    {
        Sound sound = AudioManager.Instance.Sounds.FirstOrDefault(o => o.name == clipName);
        gameObject.SetSound(audioSource, sound);
        gameObject.PlaySound(audioSource);
    }
}
