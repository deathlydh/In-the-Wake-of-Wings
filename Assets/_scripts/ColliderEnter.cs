using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEnter : MonoBehaviour
{
    [SerializeField]
    private UnityEvent go;
    [SerializeField]
    private pipes sbor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            go.Invoke();
        }
        if(other.gameObject.tag == "truba")
        {
            sbor.addpipe(other.gameObject);
        }
    }
}
