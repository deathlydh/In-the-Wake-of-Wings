using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interectiveObjects : MonoBehaviour
{
    [SerializeField] private UnityEvent actions;

    public void Action()
    {
        actions.Invoke();
    }
}
