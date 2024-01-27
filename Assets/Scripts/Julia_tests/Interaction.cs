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
    [SerializeField] private GameObject TextInter;
    [SerializeField] private float InteractRangeOut;

    [SerializeField] private ClownBehaviour clownBehaviour;
    private TurnToTarget turnToTarget;
    // Start is called before the first frame update
    void Start()
    {
        turnToTarget = clownBehaviour.GetComponent<TurnToTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        TextInter.SetActive(false);
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj) && turnToTarget.IsFacingAway()) {
                    // Debug.Log("Press E to tickle!");
                    TextInter.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E)) {
                       interactObj.Interact();
                       clownBehaviour.damaged = true;
                    }
                }
        }

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }
}
