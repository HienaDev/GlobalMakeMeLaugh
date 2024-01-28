using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUILogic : MonoBehaviour
{

    private Animator animator;
    public Animator Animator { get { return animator; } }   

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) &&
            !GameManager.instance.BananaUI.activeSelf &&
            !GameManager.instance.PieUI.activeSelf)
        {
            if (!animator.GetBool("Open"))
            {
                animator.SetBool("Close", false);
                animator.SetBool("Open", true);
            }
            else
            {
                animator.SetBool("Close", true);
                animator.SetBool("Open", false);
            }
        }
    }
}
