using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FartSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] fart;
    private AudioSource audioSourceFart;
    [SerializeField] private AudioMixerGroup fartMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceFart = gameObject.AddComponent<AudioSource>();
        audioSourceFart.outputAudioMixerGroup = fartMixer;
        audioSourceFart.spatialBlend = 1;
    }

    public void PlayFartSound()
    {
        audioSourceFart.clip = fart[Random.Range(0, fart.Length)];

        audioSourceFart.pitch = Random.Range(0.90f, 1.10f);

        audioSourceFart.Play();
    }
}
