using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToTargetGeneral : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 angles;

    // Update is called once per frame
    void Update()
    {
        RotateSprite();
    }


    private void RotateSprite()
    {
        transform.LookAt(target);

        angles = transform.eulerAngles;

        transform.rotation = Quaternion.Euler(90, angles.y, 0);
    }
}
