using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoManager : MonoBehaviour
{

    [SerializeField] private TrashBag[] lixos;
    [SerializeField] private GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            lixos[Random.Range(0, lixos.Length)].obj1 = items[i]; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
