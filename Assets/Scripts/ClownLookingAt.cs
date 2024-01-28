using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ClownLookingAt : MonoBehaviour
{

    [SerializeField] private GameObject[] eyes;
    [SerializeField] private float sightRange;

    [SerializeField] private LayerMask playerMask;
    private int playerLayer;

    private ClownBehaviour clownBehaviour;

    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        clownBehaviour = GetComponent<ClownBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject eye in eyes)
        {
            Debug.DrawRay(eye.transform.position, eye.transform.TransformDirection(Vector3.forward) * sightRange, Color.green);
        }

        foreach (GameObject eye in eyes)
        {
            RaycastHit hit;
            if (Physics.Raycast(eye.transform.position, eye.transform.TransformDirection(Vector3.forward), out hit, sightRange))
            {
                if(hit.collider.gameObject.layer == playerLayer)
                {
                    Debug.DrawRay(eye.transform.position, eye.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                    Debug.Log("FOUND PLAYER");
                    // chase
                    clownBehaviour.ChasePlayer();
                    clownBehaviour.seePlayer = true;
                }
                else
                    Debug.DrawRay(eye.transform.position, eye.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
        }
    }


}
