using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whoopie : MonoBehaviour
{

    private AudioSource audioSource;

    [SerializeField] private GameObject closeUp;
    [SerializeField] private GameObject farAway;
    [SerializeField] private GameObject deflated;
    private Transform player;
    [SerializeField] private float switchVisualDistance;
    [SerializeField] private float deactivatedTimer;

    private TurnToTargetGeneral turning;
    private bool isActive = true;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //material = GetComponent<Renderer>().material;
        turning = GetComponent<TurnToTargetGeneral>();

        player = GameManager.instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if close up
        if(Vector3.Distance(transform.position, player.position) < switchVisualDistance){

            if(isActive){
                closeUp.SetActive(true);
            } else {
                deflated.SetActive(true);
            }
            farAway.SetActive(false);
            turning.enabled = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // if far away
        if(Vector3.Distance(transform.position, player.position) > switchVisualDistance){
            if(isActive){
                closeUp.SetActive(false);
            } else {
                deflated.SetActive(false);
            }
            farAway.SetActive(true);
            turning.enabled = true;
        }
    }


    private void OnTriggerEnter(Collider other) {

        
        Debug.Log("stepped on cushion!");
        if(isActive){
            Debug.Log("farting");
            audioSource.Play(0);
            isActive = false;
            closeUp.SetActive(false);
            deflated.SetActive(true);
            StartCoroutine(StartTimer());

        }
    }


    private IEnumerator StartTimer(){

        float timePassed = 0f;

        while(timePassed < deactivatedTimer){
            timePassed += Time.deltaTime;
            yield return 0;
        }

        // whoopie cushion is active again!
        isActive = true;
        closeUp.SetActive(false);
        deflated.SetActive(false);
        farAway.SetActive(false);
    }


}
