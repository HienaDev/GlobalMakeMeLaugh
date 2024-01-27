using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BananaFall : MonoBehaviour
{

    [SerializeField] private UnityEvent triggerOnFall;

    public void TriggerFall() => triggerOnFall.Invoke();
}
