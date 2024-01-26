using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDetecting : MonoBehaviour
{

    [SerializeField] private int sampleWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
