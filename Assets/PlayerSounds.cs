using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] throwSound;
    private AudioSource audioSourceThrowSound;
    [SerializeField] private AudioMixerGroup throwSoundMixer;

    [SerializeField] private AudioClip[] hurt;
    private AudioSource audioSourceHurt;
    [SerializeField] private AudioMixerGroup hurtMixer;

    [SerializeField] private AudioClip[] marco;
    private AudioSource audioSourceMarco;
    [SerializeField] private AudioMixerGroup marcoMixer;

    [SerializeField] private AudioClip[] runningBreath;
    private AudioSource audioSourceRunningBreath;  
    [SerializeField] private AudioMixerGroup runningBreathMixer;

    [SerializeField] private AudioClip[] waterPistol;
    private AudioSource audioSourceWaterPistol;
    [SerializeField] private AudioMixerGroup waterPistolMixer;


    [SerializeField] private AudioClip[] slip;
    private AudioSource audioSourceSlip;
    [SerializeField] private AudioMixerGroup slipMixer;

    [SerializeField] private AudioClip[] steps;
    private AudioSource audioSourceSteps;
    [SerializeField] private AudioMixerGroup stepsMixer;

    //[SerializeField] private AudioClip[] hit;
    //private AudioSource audioSourceHit;
    //[SerializeField] private AudioMixerGroup hitMixer;

    //[SerializeField] private AudioClip spawn;
    //private AudioSource audioSourceSpawn;
    //[SerializeField] private AudioMixerGroup spawnMixer;

    //[SerializeField] private AudioClip roll;
    //private AudioSource audioSourceRoll;
    //[SerializeField] private AudioMixerGroup rollMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceThrowSound = gameObject.AddComponent<AudioSource>();
        audioSourceThrowSound.outputAudioMixerGroup = throwSoundMixer;
        audioSourceThrowSound.spatialBlend = 1;


        audioSourceHurt = gameObject.AddComponent<AudioSource>();
        audioSourceHurt.outputAudioMixerGroup = hurtMixer;
        audioSourceHurt.spatialBlend = 1;

        audioSourceMarco = gameObject.AddComponent<AudioSource>();
        audioSourceMarco.outputAudioMixerGroup = marcoMixer;
        audioSourceMarco.spatialBlend = 1;

        audioSourceRunningBreath = gameObject.AddComponent<AudioSource>();
        audioSourceRunningBreath.outputAudioMixerGroup = runningBreathMixer;
        audioSourceRunningBreath.spatialBlend = 1;

        audioSourceWaterPistol = gameObject.AddComponent<AudioSource>();
        audioSourceWaterPistol.outputAudioMixerGroup = waterPistolMixer;
        audioSourceWaterPistol.spatialBlend = 1;

        audioSourceSlip = gameObject.AddComponent<AudioSource>();
        audioSourceSlip.outputAudioMixerGroup = slipMixer;
        audioSourceSlip.spatialBlend = 1;

        audioSourceSteps = gameObject.AddComponent<AudioSource>();
        audioSourceSteps.outputAudioMixerGroup = stepsMixer;
        audioSourceSteps.spatialBlend = 1;

        //audioSourceHit = gameObject.AddComponent<AudioSource>();
        //audioSourceHit.outputAudioMixerGroup = hitMixer;
        //audioSourceHit.spatialBlend = 1;

        //audioSourceSpawn = gameObject.AddComponent<AudioSource>();
        //audioSourceSpawn.outputAudioMixerGroup = spawnMixer;
        //audioSourceSpawn.spatialBlend = 1;

        //audioSourceRoll = gameObject.AddComponent<AudioSource>();
        //audioSourceRoll.outputAudioMixerGroup = rollMixer;
        //audioSourceRoll.spatialBlend = 1;
    }



    public void PlayThrowSoundSound()
    {
        audioSourceThrowSound.clip = throwSound[Random.Range(0, throwSound.Length)];

        audioSourceThrowSound.pitch = Random.Range(0.9f, 1.1f);

        audioSourceThrowSound.Play();
    }

    public void PlayHurtSound()
    {
        audioSourceHurt.clip = hurt[Random.Range(0, hurt.Length)];

        audioSourceHurt.pitch = Random.Range(0.9f, 1.1f);

        audioSourceHurt.Play();
    }

    public void PlayMarcoSound()
    {
        audioSourceMarco.clip = marco[Random.Range(0, marco.Length)];

        audioSourceMarco.pitch = Random.Range(0.9f, 1.1f);

        audioSourceMarco.Play();
    }

    public void PlayRunningBreathSound()
    {
        audioSourceRunningBreath.clip = runningBreath[Random.Range(0, runningBreath.Length)];

        audioSourceRunningBreath.pitch = Random.Range(0.9f, 1.1f);

        audioSourceRunningBreath.Play();
    }

    public void PlayWaterPistolSound()
    {
        audioSourceWaterPistol.clip = waterPistol[Random.Range(0, waterPistol.Length)];

        audioSourceWaterPistol.pitch = Random.Range(0.8f, 1.2f);

        audioSourceWaterPistol.Play();
    }

    public void PlaySlipSound()
    {
        audioSourceSlip.clip = slip[Random.Range(0, slip.Length)];

        audioSourceSlip.pitch = Random.Range(0.95f, 1.05f);

        audioSourceSlip.Play();
    }

    public void PlayStepsSound()
    {
        audioSourceSteps.clip = steps[Random.Range(0, steps.Length)];

        audioSourceSteps.pitch = Random.Range(0.4f, 0.5f);

        audioSourceSteps.Play();
    }

    //public void PlayHitSound()
    //{
    //    audioSourceHit.clip = hit[Random.Range(0, hit.Length)];

    //    audioSourceHit.pitch = Random.Range(0.8f, 1.2f);

    //    audioSourceHit.Play();
    //}

    //public void PlaySpawnSound()
    //{
    //    audioSourceSpawn.clip = spawn;

    //    audioSourceSpawn.pitch = Random.Range(0.95f, 1.05f);

    //    audioSourceSpawn.Play();
    //}

    //public void PlayRollSound()
    //{
    //    audioSourceRoll.clip = roll;

    //    audioSourceRoll.pitch = Random.Range(0.95f, 1.05f);

    //    audioSourceRoll.Play();
    //}
}
