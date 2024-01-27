using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourInteract : MonoBehaviour
{
    public void FlourUI()
    {
        GameManager.instance.ToggleFlourUI();
        Destroy(gameObject);
    }
}
