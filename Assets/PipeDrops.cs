using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDrops : MonoBehaviour
{

    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    private float justDropped;
    private float dropCooldown;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        dropCooldown = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - justDropped > dropCooldown)
            Droplet();
    }

    private void Droplet()
    {
        animator.SetTrigger("Droplet");
        dropCooldown = Random.Range(minTime, maxTime);
        justDropped = Time.time;
    }
}
