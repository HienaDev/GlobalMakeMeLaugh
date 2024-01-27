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
    [SerializeField] private Texture clownSideLeft;
    [SerializeField] private Texture clownSideRight;

    private bool facingAway;


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

        float directionPlayer = Mathf.Atan2(target.transform.forward.z, target.transform.forward.x);
        float directionClown = Mathf.Atan2(transform.forward.z, transform.forward.x);
        //Debug.Log("Direction: " + direction);
        //Debug.Log("Direction clown: " + (Mathf.Rad2Deg * (directionClown)));
        Debug.Log("Direction clown - player" + (Mathf.Rad2Deg * (directionClown - Mathf.Abs(directionPlayer))));

        Debug.Log("Player direction: " + directionPlayer * Mathf.Rad2Deg);

        if(direction < 45)
        {
            material.SetTexture("_BaseMap", clownBack);
            facingAway = true;
        }
        else if (direction > 135)
        {
            material.SetTexture("_BaseMap", clownFront);
            facingAway = false;
        }
        else
        {
            if ((Mathf.Rad2Deg * (Mathf.Abs(directionPlayer)) > 50 ))
                material.SetTexture("_BaseMap", clownSideLeft);
            else
                material.SetTexture("_BaseMap", clownSideRight);
            facingAway = false;
        }



        //float direction = Vector3.Angle(transform.forward, transform.position - target.position);


        //float directionClown = Mathf.Atan2(transform.forward.z, transform.forward.x);
        //float directionPlayer = Mathf.Atan2(target.transform.forward.z, target.transform.forward.x);

        //Debug.Log("Direction clown: " + (Mathf.Rad2Deg * directionClown));
        ////Debug.Log("Direction player: " + (Mathf.Rad2Deg * directionPlayer));
        //direction = Mathf.Abs(((directionClown - directionPlayer) * Mathf.Rad2Deg));
        ////Debug.Log("Direction: " + direction);

        ////Debug.Log("Angle direction: " + direction);

        //if (direction < 45 || direction >= 315)
        //{
        //    material.SetTexture("_BaseMap", clownBack);
        //}
        //else if (direction >= 45 && direction < 135)
        //{
        //    material.SetTexture("_BaseMap", clownSideRight);
        //}
        //else if (direction >= 135 && direction < 225)
        //{
        //    material.SetTexture("_BaseMap", clownFront);
        //}
        //else if (direction >= 225 && direction < 315)
        //{
        //    material.SetTexture("_BaseMap", clownSideLeft);
        //}
    }

    public bool IsFacingAway(){
        return facingAway;
    }

}
