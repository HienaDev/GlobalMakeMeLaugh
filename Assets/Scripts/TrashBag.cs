using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBag : MonoBehaviour
{

    [SerializeField] private PlayerMovement playerMovement;

    private bool inRange;

    /*

    makes a noise 
    clown investigates noise in bag
    cannot move for x amount of time
    bool hasItem
    if hasItem, item is added to UI
    gamemanager - totalItems increases
    hasItem is deactivated

    playerMovement disable movement beginning of interaction
    enable after interaction


    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E)){
            Debug.Log("interacting w trash bag!");
        }
    }

    private void OnCollisionEnter(Collision other) {
        inRange = true;
    }

    private void OnCollisionExit(Collision other) {
        inRange = false;
    }
}
