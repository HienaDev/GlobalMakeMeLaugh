using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChantyInteract : MonoBehaviour
{
    public void ChantyUI()
    {
        GameManager.instance.ToggleChantyUI();
        Destroy(gameObject);
    }
}
