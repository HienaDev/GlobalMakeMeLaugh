using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveInteract : MonoBehaviour
{
    public void Microwave()
    {
        if (GameManager.instance.ChantyUI.activeSelf &&
            GameManager.instance.EggUI.activeSelf &&
            GameManager.instance.FlourUI.activeSelf)
        {
            Debug.Log("PIE IN THE MAKING!!!");
            GameManager.instance.ToggleChantyUI();
            GameManager.instance.ToggleEggUI();
            GameManager.instance.ToggleFlourUI();
            // wait some time for microwave animation to stop...
            GameManager.instance.TogglePieUI();
        }
    }
}
