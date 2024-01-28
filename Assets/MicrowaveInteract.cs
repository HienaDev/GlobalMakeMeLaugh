using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveInteract : MonoBehaviour
{

    private Animator animator;

    private MicrowaveSounds microSounds;



    private void Start()
    {
        animator = GetComponent<Animator>();

        microSounds = GetComponent<MicrowaveSounds>();
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

            StartCoroutine(DeactivateAfterComplete());

            //Final da corrotina, micro ondas desliga
            //

            
        }
    }

    private IEnumerator DeactivateAfterComplete()
    {

        microSounds.PlayOpenSound();

        //Iinicio de corrotina, micro ondas fica ligado
        animator.SetBool("On", true);

        yield return new WaitForSeconds(3f);

        animator.SetBool("On", false);
        microSounds.PlayDingSound();

        // wait some time for microwave animation to stop...
        GameManager.instance.TogglePieUI();
    }
}
