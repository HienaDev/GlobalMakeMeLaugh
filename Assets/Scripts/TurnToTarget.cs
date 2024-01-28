using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class TurnToTarget : MonoBehaviour
{

    private Transform target;
    [SerializeField] private GameObject spriteToRotate;

    [SerializeField] private Sprite clownBack;
    [SerializeField] private Sprite clownFront;
    [SerializeField] private Sprite clownSideLeft;
    [SerializeField] private Sprite clownSideRight;

    [SerializeField] private TouchingPlayer checkSide;

    private bool facingAway;


    private SpriteRenderer spriteRenderer;

    private Vector3 angles;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = spriteToRotate.GetComponent<SpriteRenderer>();
        target = GameManager.instance.Player.transform;
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

        spriteToRotate.transform.rotation = Quaternion.Euler(0, angles.y + 180, 0);
    }

    private void UpdateSprite()
    {
        float direction = Vector3.Angle(transform.forward, transform.position - target.position);

        if(direction < 45)
        {
            spriteRenderer.sprite = clownBack;
            facingAway = true;
        }
        else if (direction > 135)
        {
            spriteRenderer.sprite = clownFront;
            facingAway = false;
        }
        else
        {
            if (checkSide.PlayerToggle)
                spriteRenderer.sprite = clownSideLeft;
            else
                spriteRenderer.sprite = clownSideRight;

            facingAway = false;
        }

 
    }

    public bool IsFacingAway(){
        return facingAway;
    }

}
