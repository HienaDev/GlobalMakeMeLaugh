using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public void BananaUI()
    { 
        if(!GameManager.instance.PieUI.activeSelf)
        { 
            GameManager.instance.ToggleBananaUI();
            Destroy(gameObject);
        }
    }
}
