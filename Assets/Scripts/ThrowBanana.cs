using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBanana : MonoBehaviour
{

    [SerializeField] private GameObject banana;
    [SerializeField] private GameObject instantiateManager;
    [SerializeField] private GameObject firePoint;

    [SerializeField] private float strenght;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.BananaUI.activeSelf)
            {
                BananaThrow();
                GameManager.instance.ToggleBananaUI();
            }
        }
    }

    private void BananaThrow()
    {
        GameObject bananaClone = Instantiate(banana, firePoint.transform.position, transform.rotation, GameManager.instance.InstantiateManager.transform);

        Vector3 v3Force = strenght * transform.forward;
        v3Force.y += 150f;
        bananaClone.GetComponent<Rigidbody>().AddForce(v3Force);
    }
}
