using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningSounds : MonoBehaviour
{
    public void PlayRunningSound()
    {
        GameManager.instance.Player.GetComponent<PlayerSounds>().PlayRunningBreathSound();
        GameManager.instance.Player.GetComponent<PlayerSounds>().PlayStepsSound();
    }
}
