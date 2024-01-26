using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClownPathFinding : MonoBehaviour
{
    [SerializeField] private float range; 
    [SerializeField] private Transform target; 
    private NavMeshAgent agent;
    private bool chasing;

    [SerializeField] private float runningDistance;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {

        // replace mouse click with when the audio happens
        if(Input.GetMouseButtonDown(0)){
            agent.SetDestination(target.position);
            chasing = true;
        }

        if(chasing)
        {
            agent.SetDestination(target.position);
        }

        //Debug.Log((int)Vector3.Distance(transform.position, target.position));

 
         if (Vector3.Distance(transform.position, target.position) > runningDistance && chasing)
         {
            Debug.Log("stopped chasing");
            chasing = false;
         }

        // this is for random roaming
        if(agent.remainingDistance <= agent.stoppingDistance && !chasing){

            Debug.Log("Stopped");

            Vector3 point;

            if(RandomPoint(agent.transform.position, range, out point)){
                Debug.Log("New distance");
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
