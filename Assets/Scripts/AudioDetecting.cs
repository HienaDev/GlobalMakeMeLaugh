using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDetecting : MonoBehaviour
{

    [SerializeField] private int sampleWindow;
    private AudioClip microphoneClip;


    // Start is called before the first frame update
    void Start()
    {
        MicrophoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];

        
        foreach (var device in Microphone.devices)
        {
            Debug.Log(device);
        }

        //Debug.Log(microphoneName);

        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);


    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudio(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoudnessFromAudio(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if(startPosition < 0)
        {
            Debug.Log("startPosition < 0");
            return 0;
        }

        float[] waveData = new float[sampleWindow];

        clip.GetData(waveData, startPosition);

        //compute loudness
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;
    }
}
