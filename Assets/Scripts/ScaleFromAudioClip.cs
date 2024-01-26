using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{

    [SerializeField] private AudioSource source;
    [SerializeField] private Vector3 minScale;
    [SerializeField] private Vector3 maxScale;
    [SerializeField] private AudioDetecting detector;

    [SerializeField] private float loudnessSensibility;
    [SerializeField] private float threshhold;

    [SerializeField] private bool microphone;

    private float loudness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (microphone)
            loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        else
            loudness = detector.GetLoudnessFromAudio(source.timeSamples, source.clip) * loudnessSensibility;

        
        if (loudness < threshhold)
            loudness = 0;
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
        
    }
}
