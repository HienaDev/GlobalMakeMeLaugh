using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whoopie : MonoBehaviour
{

    private AudioSource audioSource;
    /*
        detect when "stood" on
        when stood on, emit audio effect

    */
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("stepped on cushion!");
        audioSource.Play(0);
    }
}
