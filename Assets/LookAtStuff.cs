using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LookAtStuff : MonoBehaviour
{

    [SerializeField] private float sightRange;
    private int bananaLayer;

    [SerializeField] private GameObject bananaUI;

    // Start is called before the first frame update
    void Start()
    {
        bananaLayer = LayerMask.NameToLayer("Banana");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * sightRange, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, sightRange))
        {


            if (hit.collider.gameObject.layer == bananaLayer)
            {
                if(Input.GetKey(KeyCode.E))
                {
                    bananaUI.SetActive(true);
                    Destroy(hit.collider.gameObject);
                }
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

            Debug.Log(hit.collider.gameObject.name);

            //Debug.Log(eye.name + " saw " + hit.collider.gameObject.name);
        }
    }
}
