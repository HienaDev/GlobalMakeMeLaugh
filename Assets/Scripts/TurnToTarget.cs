using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurnToTarget : MonoBehaviour
{

    [SerializeField] private Transform target;

    private Vector3 angles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.LookAt(target);

        angles = transform.eulerAngles;
        

        transform.rotation = Quaternion.Euler(90, angles.y, 0);
    }
}
