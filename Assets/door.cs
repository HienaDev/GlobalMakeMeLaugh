using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] Animator DoorCtrl;
    [SerializeField] Animation openDoor;
    [SerializeField] Animation closeDoor;

    private bool doorOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        DoorCtrl = GetComponent<Animator>();
    }

    public void DoorInteract() {
        if (doorOpen == false) {
            doorOpen = true;
        }
        else {
            doorOpen = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen) {
            DoorCtrl.Play("portinha_abrir");
        }
        else {
            DoorCtrl.Play("portinha_fechar");
        }
    }
}
