using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipes : MonoBehaviour
{
    // Start is called before the first frame update
    public int CurCount = 0;
    [SerializeField]
    private int count;
    [SerializeField]
    private podbor pr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addpipe(GameObject gobj)
    {
        CurCount++;
        Destroy(gobj);
        pr.enabled = true;
        collectpipe();
    }
    private void collectpipe()
    {
        if(CurCount == count)
        {
            enabled= false;
        }
    }
}
