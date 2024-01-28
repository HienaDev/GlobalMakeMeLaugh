using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSounds : MonoBehaviour
{

    [SerializeField] private AudioSource audioDeathLaugh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveSound()
    {
        audioDeathLaugh.volume = 0;
    }
}
