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

        // this is for random roaming
        if(agent.remainingDistance <= agent.stoppingDistance && !chasing){
            Vector3 point;
            if(RandomPoint(agent.transform.position, range, out point)){
                agent.SetDestination(point);
            }
        }
    }

    // don't ask me to explain this
    private bool RandomPoint(Vector3 center, float range, out Vector3 result){

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        UnityEngine.AI.NavMeshHit hit;
        if(UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas)){
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
