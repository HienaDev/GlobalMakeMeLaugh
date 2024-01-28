using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BananaSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] banana;
    private AudioSource audioSourceBanana;
    [SerializeField] private AudioMixerGroup bananaMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceBanana = gameObject.AddComponent<AudioSource>();
        audioSourceBanana.outputAudioMixerGroup = bananaMixer;
        audioSourceBanana.spatialBlend = 1;

    }

    public void PlayBananaSound()
    {
        audioSourceBanana.clip = banana[Random.Range(0, banana.Length)];

        audioSourceBanana.pitch = Random.Range(0.90f, 1.10f);

        audioSourceBanana.Play();
    }
}
