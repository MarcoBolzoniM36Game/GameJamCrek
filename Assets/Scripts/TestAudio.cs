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
        Sound sound = AudioManager.Instance.Sounds.FirstOrDefault(o => o.name == "BackgroundMusic");
        gameObject.SetSound(audioSource, sound);
        gameObject.PlaySound(audioSource);
    }


}
