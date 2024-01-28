using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonFloorBanana : MonoBehaviour
{

    [SerializeField] private GameObject floorBanana;

    [SerializeField] private LayerMask floorLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        int x = 1 << collision.gameObject.layer;

        if (x == floorLayer.value)
        {

            Instantiate(floorBanana, transform.position, transform.rotation, GameManager.instance.InstantiateManager.transform);//.GetComponent<BananaSound>().PlayBananaSound(); ;


            Destroy(gameObject);
        }
    }
}
