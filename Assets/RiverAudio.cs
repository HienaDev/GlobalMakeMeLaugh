using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RiverAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] river;
    private AudioSource audioSourceRiver;
    [SerializeField] private AudioMixerGroup riverMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceRiver = gameObject.AddComponent<AudioSource>();
        audioSourceRiver.outputAudioMixerGroup = riverMixer;
        audioSourceRiver.spatialBlend = 1;
    }

    public void PlayRiverSound()
    {
        audioSourceRiver.clip = river[Random.Range(0, river.Length)];

        audioSourceRiver.pitch = Random.Range(0.95f, 1.05f);

        audioSourceRiver.Play();
    }
}
