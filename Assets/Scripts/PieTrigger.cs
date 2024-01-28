using UnityEngine;
using UnityEngine.Events;

public class PieTrigger : MonoBehaviour {

	[SerializeField] private UnityEvent interact;
	
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.layer == LayerMask.NameToLayer("Pie")){
			interact.Invoke();
		}
	}
}