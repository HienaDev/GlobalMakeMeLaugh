using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownSpawn : MonoBehaviour {
	
	[SerializeField] private List<Transform> spawnPoints = new List<Transform>();

	public void SpawnAtRandomPoint(){
		Transform newPos = spawnPoints[Random.Range(0, spawnPoints.Count)];

		if(Vector3.Distance(newPos.position, GameManager.instance.Player.transform.position) < 100){
			SpawnAtRandomPoint();
			return;
		}
		gameObject.transform.position = new Vector3(newPos.position.x, transform.position.y, newPos.position.z);
	}
}