using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scales : MonoBehaviour
{
    [SerializeField] private ScalesPlane _planeLeft;
    [SerializeField] private ScalesPlane _planeRigt;
    public float equalityMass = 3;
    private void OnEnable()
    {
        _planeLeft.BodyCollisionEnterEvent += CheckEquals;
        _planeRigt.BodyCollisionEnterEvent += CheckEquals;
    }

    private void OnDisable()
    {
        _planeLeft.BodyCollisionEnterEvent -= CheckEquals;
        _planeRigt.BodyCollisionEnterEvent -= CheckEquals;
    }

    private void CheckEquals()
    {
       if(_planeLeft.BodyMass == _planeRigt.BodyMass && _planeRigt.BodyMass == equalityMass)
       {
            Debug.Log("=)))");
       }
    }
}
