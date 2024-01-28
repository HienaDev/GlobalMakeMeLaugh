using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TrashBag : MonoBehaviour
{

    [SerializeField] private GameObject obj1;
    [SerializeField] private GameObject obj2;
    [SerializeField] private GameObject obj3;

    public void TrashInteract() {
        Vector3 auxPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 4f, gameObject.transform.position.z);
        Instantiate(obj1, auxPos, quaternion.identity, GameManager.instance.InstantiateManager.transform);

        auxPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 4f, gameObject.transform.position.z);
        Instantiate(obj2, auxPos, quaternion.identity, GameManager.instance.InstantiateManager.transform);

        auxPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 4f, gameObject.transform.position.z);
        Instantiate(obj3, auxPos, quaternion.identity, GameManager.instance.InstantiateManager.transform);
        Destroy(gameObject);

    }
}
