using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToTargetMicrowave : MonoBehaviour
{
    private Transform target;

    private Vector3 angles;

    private void Start()
    {
        target = GameManager.instance.Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateSprite();
    }


    private void RotateSprite()
    {
        transform.LookAt(target);

        angles = transform.eulerAngles;

        transform.rotation = Quaternion.Euler(0, angles.y - 180, 0);
    }
}
