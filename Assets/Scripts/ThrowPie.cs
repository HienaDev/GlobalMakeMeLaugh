using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPie : MonoBehaviour {

    [SerializeField] private GameObject pie;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private Animator anim;

    [SerializeField] private float strength;

    [SerializeField] private PlayerSounds playerSounds;

    // Start is called before the first frame update
    void Start()
    {
        playerSounds = GetComponent<PlayerSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.PieUI.activeSelf)
            {
                PieThrow();
		        anim.SetTrigger("throw");

                playerSounds.PlayThrowSoundSound();

                StartCoroutine(ThrowPieAnim(1f));
            }
        }
    }

    private IEnumerator ThrowPieAnim(float time){
	float elapsed = 0f;

	while(elapsed < time){
		elapsed += Time.deltaTime;
		yield return 0;
	}

	GameManager.instance.TogglePieUI();
    }

    private void PieThrow()
    {
        GameObject pieClone = Instantiate(pie, firePoint.transform.position, transform.rotation, GameManager.instance.InstantiateManager.transform);

        Vector3 v3Force = strength * transform.forward;
        v3Force.y += 150f;
        pieClone.GetComponent<Rigidbody>().AddForce(v3Force);
	    StartCoroutine(DeletePie(pieClone));
    }

    private IEnumerator DeletePie(GameObject pie){
	float elapsed = 0f;

	while(elapsed < 2f){
		elapsed += Time.deltaTime;
		yield return 0;
	}

	Destroy(pie);

    }
}