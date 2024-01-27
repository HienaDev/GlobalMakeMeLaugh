public abstract class IClownState {


	public abstract void Enter(ClownBehaviour clownBehaviour);

	public abstract void Update(ClownBehaviour clownBehaviour);

	public abstract IClownState Transition(ClownBehaviour clownBehaviour);

	public abstract void NextState(IClownState clownState, ClownData clownData);



}