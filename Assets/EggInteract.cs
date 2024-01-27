using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public void EggUI()
    {
        GameManager.instance.ToggleEggUI();
        Destroy(gameObject);
    }
}
