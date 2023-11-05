using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sundList : MonoBehaviour
{
    [SerializeField]
    private EventReference btnClickSound;
    [SerializeField]
    private EventReference doorOpenSound;
    [SerializeField]
    private EventReference valveSound;
    [SerializeField]
    private EventReference pipeRotateSound;
    [SerializeField]
    private EventReference grabSound;
    public void btnSound()
    {
        RuntimeManager.PlayOneShot(btnClickSound, this.gameObject.transform.position);
    }
    public void doorOpen()
    {
        RuntimeManager.PlayOneShot(doorOpenSound, this.gameObject.transform.position);
    }
    public void valve()
    {
        RuntimeManager.PlayOneShot(valveSound, this.gameObject.transform.position);
    }
    public void pipeRoate()
    {
        RuntimeManager.PlayOneShot(pipeRotateSound, this.gameObject.transform.position);
    }
    public void grab()
    {
        RuntimeManager.PlayOneShot(grabSound, this.gameObject.transform.position);
    }
}
