using UnityEngine;


public class ClownPatrol 
{
	private ClownData clownData;
	private ClownBehaviour clownBehaviour;

	public void Enter(ClownBehaviour clownBehaviour, ClownData clownData){
		this.clownData = clownData;
		this.clownBehaviour = clownBehaviour;
		clownBehaviour.Roam();
		clownBehaviour.GetNavAgent().speed = clownData.roamSpeed;
	}


	public void Update(){

		if(clownBehaviour.damaged){
			Debug.Log("ow! running awaaaaay!");
			return;
		}

		// replace mouse click with when the audio happens
		// when we hear an audio, we go investigate....
		
		if(Input.GetMouseButtonDown(0)){
			clownBehaviour.Investigate();
		}

		if(clownBehaviour.IsChasing())
		{
			if(clownBehaviour.GetNavAgent().speed != clownData.chaseSpeed){
				clownBehaviour.GetNavAgent().speed = clownData.chaseSpeed;
			}

			clownBehaviour.ChasePlayer();

			if (Vector3.Distance(clownBehaviour.gameObject.transform.position, clownBehaviour.GetPlayerPosition().position) > clownData.chaseThreshold)
			{
				clownBehaviour.GetNavAgent().speed = clownData.roamSpeed;
				clownBehaviour.Roam();
				return;
			}
		}

		// this is for random roaming
		if(clownBehaviour.GetNavAgent().remainingDistance <= clownBehaviour.GetNavAgent().stoppingDistance && !clownBehaviour.IsChasing())
		{

			if(clownBehaviour.dashing){
				Debug.Log("no more dashing");
				clownBehaviour.dashing = false;
				clownBehaviour.GetNavAgent().speed = clownData.roamSpeed;
				clownBehaviour.DisplayWarning();
			}
			clownBehaviour.Roam();
		}

	}


}