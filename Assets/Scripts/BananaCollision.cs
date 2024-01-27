using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    { 
        other.gameObject.GetComponent<BananaFall>().TriggerFall(); 
        Destroy(gameObject);
    }

}
