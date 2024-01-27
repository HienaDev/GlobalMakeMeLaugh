using UnityEngine;


[CreateAssetMenu(fileName = "ClownData", menuName = "Data", order = 0)]
public class ClownData : ScriptableObject {

	public float chaseThreshold;
	public float roamSpeed;
	public float chaseSpeed;
	public float playerDetectionThreshold; // from behind
	
}