using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingPlayer : MonoBehaviour
{

    private bool playerToggle = false;

    public bool PlayerToggle { get => playerToggle; }
    
    private void OnTriggerEnter(Collider other)
    {
        playerToggle = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerToggle = false;
    }
}
