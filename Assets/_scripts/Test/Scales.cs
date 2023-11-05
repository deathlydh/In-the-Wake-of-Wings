using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scales : MonoBehaviour
{
    [SerializeField] private ScalesPlane _planeLeft;
    [SerializeField] private ScalesPlane _planeRigt;
    //public float equalityMass = 3;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private UnityEvent go;
    public float o;
    private void OnEnable()
    {
        _planeLeft.BodyCollisionEnterEvent += CheckEquals;
        _planeRigt.BodyCollisionEnterEvent += CheckEquals;
        _planeLeft.BodyCollisionExitEvent += CheckEquals;
        _planeRigt.BodyCollisionExitEvent += CheckEquals;
    }

    private void OnDisable()
    {
        _planeLeft.BodyCollisionEnterEvent -= CheckEquals;
        _planeRigt.BodyCollisionEnterEvent -= CheckEquals;
        _planeLeft.BodyCollisionExitEvent -= CheckEquals;
        _planeRigt.BodyCollisionExitEvent -= CheckEquals;
    }

    private void CheckEquals()
    {
        
        o = (_planeRigt.BodyMass - _planeLeft.BodyMass) / _planeLeft.BodyMass + _planeRigt.BodyMass;
       if (_planeLeft.BodyMass == _planeRigt.BodyMass)// && _planeRigt.BodyMass == equalityMass)
       {
            anim.SetFloat("Blend", 0);
            //Debug.Log("=)))");
            go.Invoke();
       }
        else
        {
           // anim.SetFloat("Blend", (_planeRigt.BodyMass - _planeLeft.BodyMass +0.01f) / _planeLeft.BodyMass + _planeRigt.BodyMass);
           if(_planeLeft.BodyMass > _planeRigt.BodyMass)
            {
                if (_planeRigt.BodyMass > 0)
                {
                    anim.SetFloat("Blend", -(_planeRigt.BodyMass / _planeLeft.BodyMass));
                } 
                else
                {
                    anim.SetFloat("Blend", -1);
                }
            }
            if (_planeLeft.BodyMass < _planeRigt.BodyMass)
            {
                if (_planeLeft.BodyMass > 0)
                {
                    anim.SetFloat("Blend", (_planeLeft.BodyMass / _planeRigt.BodyMass));
                }
                else
                {
                    anim.SetFloat("Blend", 1);
                }
            }
        }
    }
}
