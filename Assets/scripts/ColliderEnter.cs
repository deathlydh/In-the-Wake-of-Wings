using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEnter : MonoBehaviour
{
    [SerializeField]
    private UnityEvent go;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            go.Invoke();
        }
    }
}
