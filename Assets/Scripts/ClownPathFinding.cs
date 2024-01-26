using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClownPathFinding : MonoBehaviour
{
    [SerializeField] private float range; 
    [SerializeField] private Transform target; 
    [SerializeField] private LayerMask layer;
    private NavMeshAgent agent;
    private bool chasing;
    private bool investigating;

    [SerializeField] private float runningDistance;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {

        // replace mouse click with when the audio happens
        // when we hear an audio, we go investigate....
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("heard the player! going to source of sound");
            agent.SetDestination(target.position);

            investigating = true;
        }


        // if player is nearby, time to chase!!!
        if(Vector3.Distance(transform.position, target.position) < 5){
            chasing = true;
            investigating = false;
            Debug.Log("chasing time");
        }

        if(chasing)
        {
            agent.SetDestination(target.position);
        }

 
         if (Vector3.Distance(transform.position, target.position) > runningDistance && chasing)
         {
            Debug.Log("stopped chasing");
            chasing = false;
         }

        // this is for random roaming, not chasing or investigating
        if(agent.remainingDistance <= agent.stoppingDistance && !chasing){


            if(investigating){
                Debug.Log("gonna stop investigating now");
                investigating = false;
            }

            Debug.Log("Going to choose a new random roam");

            Vector3 point;

            if(RandomPoint(agent.transform.position, range, out point)){
                Debug.Log("New random roam location picked");
                agent.SetDestination(point);
            }
        }
    }

    // don't ask me to explain this
    private bool RandomPoint(Vector3 center, float range, out Vector3 result){

        Vector3 randomPoint = center + Random.insideUnitSphere * range;


        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas);

        result = hit.position;
        return true;
    }
}
