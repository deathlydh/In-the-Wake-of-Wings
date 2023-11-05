using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScalesPlane : MonoBehaviour
{
    public Action BodyCollisionEnterEvent;
    public Action BodyCollisionExitEvent;

    private float _bodyMass;
    public float BodyMass => _bodyMass;


    private void OnTriggerEnter(Collider other)
    {

        Debug.Log($"{gameObject.name} On trigger enter ");
        if (other.TryGetComponent(out Rigidbody rb))
        {
             Debug.Log($"{gameObject.name} collision is has rb");
            _bodyMass += rb.mass;
            BodyCollisionEnterEvent?.Invoke();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rb))
        {
            _bodyMass -= rb.mass;
            BodyCollisionExitEvent?.Invoke();
            Debug.Log(_bodyMass);
        }
    }
}
