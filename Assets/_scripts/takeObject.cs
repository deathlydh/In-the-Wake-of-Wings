using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeObject : MonoBehaviour
{
    [SerializeField]
    private Transform pivot;
    [SerializeField]
    private podbor pr;
    private Rigidbody object_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (object_ != null)
        {
            object_.isKinematic = true;
            object_.MovePosition(pivot.position);
            pr.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            object_.isKinematic = false;
            object_ = null;
            pr.enabled = true;
        }
    }
    public void prilip(Rigidbody obj)
    {
        object_ = obj;
    }
}
