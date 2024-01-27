using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClownBehaviour : MonoBehaviour
{
    [SerializeField] private float range; // range used to choose new random location 
    [SerializeField] private Transform target; // player 

    private NavMeshAgent agent;
    private bool chasing;
    private bool investigating;
    public bool damaged { get; set;}

    [SerializeField] private AudioDetecting detector;
    [SerializeField] List<ClownData> clownData = new List<ClownData>();
    //[SerializeField] private CameraShake cameraShake;

    private IClownState currentState;

    void Start()
    {
  
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // create initial states here
        StartState startState = new StartState();
        MidState midState = new MidState();
        FinalState finalState = new FinalState();

        startState.NextState(midState, clownData[0]);
        midState.NextState(finalState, clownData[1]);
        finalState.NextState(null, clownData[2]);

        currentState = startState;
        startState.Enter(this);

    }

    void Update()
    {

        currentState.Update(this);
        IClownState clownState = currentState.Transition(this);

        if(clownState == null){
            Debug.Log("game over!");
            return;
        }

        if(clownState != currentState){
            currentState = clownState;
            currentState.Enter(this);
        }

    }


    public void Shake(){
        //StartCoroutine(cameraShake.Shake(.5f, 1f));
    }

    public bool IsChasing(){
        return chasing;
    }

    public Transform GetPlayerPosition(){
        return target;
    }

   
    public void ChasePlayer(){
        if(!chasing){
            Shake();
        }
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

    public void Roam(){
        Debug.Log("Going to choose a new random roam");
        chasing = false;
        investigating = false;

        Vector3 point;

        if(RandomPoint(agent.transform.position, range, out point)){
            Debug.Log("New random roam location picked");
            agent.SetDestination(point);
        }
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
