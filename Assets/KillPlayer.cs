using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    private ClownBehaviour clownBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        clownBehaviour = GetComponentInParent<ClownBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (clownBehaviour.seePlayer)
        {
            GameManager.instance.BananaUI.SetActive(false);
            GameManager.instance.PieUI.SetActive(false);
            GameManager.instance.RunningUI.SetActive(false);


            GameManager.instance.DeathUI.SetActive(true);
        }
    }
}
