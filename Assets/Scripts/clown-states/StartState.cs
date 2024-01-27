using UnityEngine;

public class StartState : IClownState {

	// clown is slower to roam and gives up on chasing sooner
	// can be tickled

	private IClownState nextState;
	private bool pressed;
	private ClownData clownData;
	private bool tickled;

	public override void Enter(ClownBehaviour clownBehaviour){
		Debug.Log("Entering starting state!");
		clownBehaviour.Roam();
		clownBehaviour.GetNavAgent().speed = clownData.roamSpeed;
	}

	public override IClownState Transition(ClownBehaviour clownBehaviour){
		if (tickled){
			// reset damage for next round
			clownBehaviour.damaged = false;

			// trigger tickle animation here!
			return nextState;
		}

		return this;
	}

	public override void Update(ClownBehaviour clownBehaviour){

		if(clownBehaviour.damaged){
			tickled = true;
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
				clownBehaviour.Roam();
				return;
			}
		}

		// this is for random roaming
		if(clownBehaviour.GetNavAgent().remainingDistance <= clownBehaviour.GetNavAgent().stoppingDistance && !clownBehaviour.IsChasing())
		{
			clownBehaviour.Roam();
		}

	}

	public override void NextState(IClownState clownState, ClownData clownData){
		this.nextState = clownState;
		this.clownData = clownData;
	}


}