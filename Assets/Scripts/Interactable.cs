using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    [SerializeField] private UnityEvent interact;

    public void Interact()
    {
        GameManager.instance.Player.GetComponent<PlayerSounds>().PlayDiscoverSound();
        interact.Invoke();
    }
}
