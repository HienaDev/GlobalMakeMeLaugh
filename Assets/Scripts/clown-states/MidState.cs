using UnityEngine;

public class MidState : IClownState {


	private IClownState nextState;
	private bool pressed;
	private ClownData clownData;

	public override void Enter(ClownBehaviour clownBehaviour){
		Debug.Log("entering mid state");
	}

	public override IClownState Transition(ClownBehaviour clownBehaviour){
		return pressed ? nextState : this;
	}

	public override void Update(ClownBehaviour clownBehaviour){

		if(Input.GetKeyDown("space")){
			pressed = true;
		}

	}

	public override void NextState(IClownState clownState, ClownData clownData){
		this.nextState = clownState;
		this.clownData = clownData;
	}
}