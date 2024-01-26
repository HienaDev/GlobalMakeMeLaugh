using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClownPathFinding : MonoBehaviour
{
    [SerializeField] private float range; 
    [SerializeField] private Transform target; 
    [SerializeField] private float chaseDistance;
    private NavMeshAgent agent;
    private bool chasing;
    private bool investigating;

    [SerializeField] private AudioDetecting detector;
    [SerializeField] private float runningDistance;
    [SerializeField] private bool microphone;
    [SerializeField] private float loudnessSensibility;

    void Start()
    {
  
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {

        // replace mouse click with when the audio happens
        // when we hear an audio, we go investigate....
        if (microphone){
            float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
            //Debug.Log(loudness);
            // if loudness > certain amount
                    // Investigate()
        }
        if(Input.GetMouseButtonDown(0)){
            Investigate();
        }


        // if player is nearby, time to chase!!!
        if(Vector3.Distance(transform.position, target.position) < chaseDistance){
            Chase();
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

            if(investigating){
                Debug.Log("gonna stop investigating now");
                investigating = false;
            }

            Roam();
          
        }
    }


    private void Investigate(){
        Debug.Log("heard the player! going to source of sound");
        agent.SetDestination(target.position);
        investigating = true;
    }

    private void Chase(){
        Debug.Log("chasing time");
        chasing = true;
        investigating = false;
    }

    private void Roam(){
        Debug.Log("Going to choose a new random roam");

        Vector3 point;

        if(RandomPoint(agent.transform.position, range, out point)){
            Debug.Log("New random roam location picked");
            agent.SetDestination(point);
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
