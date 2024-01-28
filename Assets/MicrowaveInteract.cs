using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveInteract : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Microwave()
    {
        if (GameManager.instance.ChantyUI.activeSelf &&
            GameManager.instance.EggUI.activeSelf &&
            GameManager.instance.FlourUI.activeSelf)
        {
            Debug.Log("PIE IN THE MAKING!!!");
            GameManager.instance.ToggleChantyUI();
            GameManager.instance.ToggleEggUI();
            GameManager.instance.ToggleFlourUI();


            //Iinicio de corrotina, micro ondas fica ligado
            animator.SetBool("On", true);

            //Final da corrotina, micro ondas desliga
            animator.SetBool("On", false);

            // wait some time for microwave animation to stop...
            GameManager.instance.TogglePieUI();
        }
    }
}
