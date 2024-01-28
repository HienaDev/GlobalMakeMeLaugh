using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class ClownBehaviour : MonoBehaviour
{


    [SerializeField] private float range; // range used to choose new random location 
    private Transform target; // player 

    public bool seePlayer {get; set;}

    private NavMeshAgent agent;
    private bool chasing;
    private bool investigating;
    public bool dashing { get; set;}
    public bool damaged { get; set;}


    // POSSIBLE WAYS TO MAKE HIM LAUGH
    public bool beenTickled {get; set;}
    public bool beenCaked {get; set;}
    public bool beenBananad {get; set;}

    private bool inRange;
    private TickleBehaviour tickleBehaviour;
    private bool animComplete = false;
    private bool animating = false;

    [SerializeField] private GameObject laughingAnim;
    [SerializeField] private GameObject idleAnim;
    [SerializeField] private float seeDistance;
    [SerializeField] private ClownData clownData;

    private TurnToTarget turnToTarget;
    private ClownPatrol clownPatrol;
    private ClownSpawn clownSpawn;


    void Start()
    {
        turnToTarget = GetComponent<TurnToTarget>();
        clownSpawn = GetComponent<ClownSpawn>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        tickleBehaviour = GetComponentInChildren<TickleBehaviour>();
        clownPatrol = new ClownPatrol();
        target = GameManager.instance.Player.transform;

        clownPatrol.Enter(this, clownData);
    }

    void Update()
    {

        /*if(Input.GetKey(KeyCode.Space)){
            clownSpawn.SpawnAtRandomPoint();
        }*/

        if(animating && !animComplete){
            return;
        }

        if(!beenTickled && tickleBehaviour.inRange && turnToTarget.IsFacingAway()){
            GameManager.instance.TickleUI.SetActive(true);
        }

        if(!tickleBehaviour.inRange){
            GameManager.instance.TickleUI.SetActive(false);
        }

        if(Input.GetKey(KeyCode.E) && GameManager.instance.TickleUI.activeInHierarchy){
            Debug.Log("tickle tiiiiime!!!");
            DamageClown();
            beenTickled = true;
        }

        clownPatrol.Update();

        if(Vector3.Distance(transform.position, target.position) > seeDistance && seePlayer == true){
            seePlayer = false;
        }

    }

    private IEnumerator DamageAfterWait(float waitTime){
        float elapsed = 0f;

        while(elapsed < waitTime){
            elapsed += Time.deltaTime;
            yield return 0;
        }

        DamageClown();
    }

    public void SeePlayerSlip(){
        Debug.Log("slipped on banana");
        Debug.Log("been bananed" + beenBananad);
        Debug.Log("see player" + seePlayer);
        if(!beenBananad && seePlayer){
            Debug.Log("THE PLAYER FELL ON BANANA HAHAHAHAHA");
            beenBananad = true;
            agent.SetDestination(transform.position);
            agent.speed = 0;
            damaged = true;
            StartCoroutine(DamageAfterWait(2f));
        }
    }

    public void DamageClown(){
        animComplete = false;
        animating = true;
        idleAnim.SetActive(false);
        laughingAnim.SetActive(true);
        agent.speed = 0;
        StartCoroutine(CompleteLaughter(1.15f));
        damaged = true; 
    }


    private IEnumerator DeactivateAfterComplete(float duration, GameObject element)
    {
       float timeElapsed = 0f;

        while(timeElapsed < duration){
            timeElapsed += Time.deltaTime;
            yield return 0;
        }
        element.SetActive(false);
        
    }
    private IEnumerator CompleteLaughter(float animDuration){
        float timeElapsed = 0f;

        while(timeElapsed < animDuration){
            timeElapsed += Time.deltaTime;
            yield return 0;
        }

        animating = false;
        animComplete = true;
        damaged = false;
        laughingAnim.SetActive(false);
        idleAnim.SetActive(true);
        //agent.speed = clownData.dashSpeed;
        //Dash();
        clownSpawn.SpawnAtRandomPoint();
        GameManager.instance.WarningUI.SetActive(true);
        StartCoroutine(DeactivateAfterComplete(2f, GameManager.instance.WarningUI));
        agent.speed = clownData.roamSpeed;
    }


    public bool IsChasing(){
        return chasing;
    }

    public Transform GetPlayerPosition(){
        return target;
    }

   
    public void ChasePlayer(){
        investigating = false;
        chasing = true;
        agent.SetDestination(target.position);
    }

    public NavMeshAgent GetNavAgent(){
        return agent;
    }

    public void Investigate(){
        Debug.Log("heard the player! going to source of sound");
        agent.SetDestination(target.position);
        investigating = true;
    }

    public void Dash(){
        Debug.Log("run away!");
        dashing = true;
        chasing = false;
        investigating = false;
    }

    public void Roam(){
        Debug.Log("Going to choose a new random roam");
        chasing = false;
        investigating = false;

        Vector3 point;

        if(dashing){
            if(RandomPoint(agent.transform.position, 300, out point)){
            Debug.Log("New dash location");
            agent.SetDestination(point);
            }
        } else if(RandomPoint(agent.transform.position, range, out point)){
            Debug.Log("New random roam location picked");
            agent.SetDestination(point);
        }
    }

    public void DisplayWarning(){

        GameManager.instance.WarningUI.SetActive(true);
        StartCoroutine(DeactivateAfterComplete(2f, GameManager.instance.WarningUI));

    }

    // don't ask me to explain this
    public bool RandomPoint(Vector3 center, float range, out Vector3 result){

        Vector3 randomPoint = center + Random.insideUnitSphere * range;


        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas);

        result = hit.position;
        return true;
    }



}
