using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Audio;

public class DropletAudio : MonoBehaviour
{

    [SerializeField] private AudioClip[] droplet;
    private AudioSource audioSourceDroplet;
    [SerializeField] private AudioMixerGroup dropletMixer;

    private GameObject dropletObject;

    // Start is called before the first frame update
    void Start()
    {
        dropletObject = GetComponentInChildren<Droplet>().gameObject;

        audioSourceDroplet = dropletObject.AddComponent<AudioSource>();
        audioSourceDroplet.outputAudioMixerGroup = dropletMixer;
        audioSourceDroplet.spatialBlend = 1;
    }

    public void PlayDropletSound()
    {
        audioSourceDroplet.clip = droplet[Random.Range(0, droplet.Length)];

        audioSourceDroplet.pitch = Random.Range(0.95f, 1.05f);

        audioSourceDroplet.Play();
    }
}
