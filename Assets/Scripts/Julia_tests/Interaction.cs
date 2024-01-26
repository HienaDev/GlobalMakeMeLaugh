using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable {
    public void Interact();
}

public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform InteractorSource;
    [SerializeField] private float InteractRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) {
            //Debug.Log("Press E to tickle!");            
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    Debug.Log("Press E to tickle!");
                    if (Input.GetKeyDown(KeyCode.E)) {
                    interactObj.Interact();
                }
            }
        }
    }
}
