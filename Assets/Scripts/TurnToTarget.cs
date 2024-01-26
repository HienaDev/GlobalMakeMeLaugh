using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class TurnToTarget : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private GameObject spriteToRotate;

    [SerializeField] private Texture clownBack;
    [SerializeField] private Texture clownFront;
    [SerializeField] private Texture clownSide;


    private Material material;

    private Vector3 angles;

    // Start is called before the first frame update
    void Start()
    {
        material = spriteToRotate.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        RotateSprite();
        UpdateSprite();
    }


    private void RotateSprite()
    {
        spriteToRotate.transform.LookAt(target);

        angles = spriteToRotate.transform.eulerAngles;

        spriteToRotate.transform.rotation = Quaternion.Euler(90, angles.y, 0);
    }

    private void UpdateSprite()
    {
        float direction = Vector3.Angle(transform.forward, transform.position - target.position);

        Debug.Log("Angle direction: " + direction);

        if(direction < 45)
        {
            material.SetTexture("_BaseMap", clownBack);
        }
        else if (direction > 135)
        {
            material.SetTexture("_BaseMap", clownFront);
        }
        else
        {
            material.SetTexture("_BaseMap", clownSide);
        }
    }
}
