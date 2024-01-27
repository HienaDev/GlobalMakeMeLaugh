using UnityEngine;

public class StartState : IClownState {

	// clown is slower to roam and gives up on chasing sooner
	// can be tickled

	private IClownState nextState;
	private bool pressed;
	private ClownData clownData;

	public override void Enter(ClownBehaviour clownBehaviour){
		Debug.Log("Entering starting state!");
		clownBehaviour.Roam();
		clownBehaviour.GetNavAgent().speed = clownData.roamSpeed;
	}

	public override IClownState Transition(ClownBehaviour clownBehaviour){
		if (clownBehaviour.damaged){
			// reset damage for next round
			clownBehaviour.damaged = false;
			return nextState;
		}

		return this;
	}

	public override void Update(ClownBehaviour clownBehaviour){

		if(clownBehaviour.damaged){
			// make clown laugh
			// mad dash away
			// ui of (I won't fall for that again...)
			Debug.Log("ow! been tickled! running awaaaaay!");
			clownBehaviour.dashing = true;
			clownBehaviour.GetNavAgent().speed = clownData.dashSpeed;
			clownBehaviour.Dash();
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
			}
			clownBehaviour.Roam();
		}

	}

	public override void NextState(IClownState clownState, ClownData clownData){
		this.nextState = clownState;
		this.clownData = clownData;
	}


}