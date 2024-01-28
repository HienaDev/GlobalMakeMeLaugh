using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveInteract : MonoBehaviour
{

    private Animator animator;

    private MicrowaveSounds microSounds;

    [SerializeField] private Sprite microwaveLight;
    private Sprite defaultSprite;

    private bool ready;

    private void Start()
    {
        animator = GetComponent<Animator>();

        microSounds = GetComponent<MicrowaveSounds>();

        defaultSprite = GetComponent<SpriteRenderer>().sprite;

        ready = false;
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

        Debug.Log(ready);

        if(!GameManager.instance.BananaUI.activeSelf && ready)
        {
            //GetComponent<SpriteRenderer>().sprite = defaultSprite;

            animator.SetTrigger("PickUp");

            // wait some time for microwave animation to stop...
            GameManager.instance.TogglePieUI();
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

        ready = true;

        

    }
}
