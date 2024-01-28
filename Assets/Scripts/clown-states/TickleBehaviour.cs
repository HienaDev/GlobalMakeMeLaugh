using UnityEngine;

public class TickleBehaviour : MonoBehaviour {

	public bool inRange {get; set;}

	private void OnTriggerEnter(Collider other) {
       		Debug.Log("enter clown");
        	inRange = true;
    	}

    	private void OnTriggerExit(Collider other) {
        	inRange = false;
        	Debug.Log("exit clown");
    	}
	
}