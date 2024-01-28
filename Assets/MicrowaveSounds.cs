using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MicrowaveSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] open;
    private AudioSource audioSourceOpen;
    [SerializeField] private AudioMixerGroup openMixer;

    [SerializeField] private AudioClip[] ding;
    private AudioSource audioSourceDing;
    [SerializeField] private AudioMixerGroup dingMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceOpen = gameObject.AddComponent<AudioSource>();
        audioSourceOpen.outputAudioMixerGroup = openMixer;
        audioSourceOpen.spatialBlend = 1;

        audioSourceDing = gameObject.AddComponent<AudioSource>();
        audioSourceDing.outputAudioMixerGroup = dingMixer;
        audioSourceDing.spatialBlend = 1;

    }


    public void PlayOpenSound()
    {
        audioSourceOpen.clip = open[Random.Range(0, open.Length)];

        audioSourceOpen.pitch = Random.Range(0.90f, 1.10f);

        audioSourceOpen.Play();
    }

    public void PlayDingSound()
    {
        audioSourceDing.clip = ding[Random.Range(0, ding.Length)];

        audioSourceDing.pitch = Random.Range(0.90f, 1.10f);

        audioSourceDing.Play();
    }
}
