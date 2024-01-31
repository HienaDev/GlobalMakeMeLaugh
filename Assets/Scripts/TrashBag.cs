using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TrashBag : MonoBehaviour
{

    public GameObject obj1;


    public void TrashInteract() {

        if (obj1 != null) {
            Vector3 auxPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 4f, gameObject.transform.position.z);
            Instantiate(obj1, auxPos, quaternion.identity, GameManager.instance.InstantiateManager.transform);
                }

        Destroy(gameObject);

    }
}
