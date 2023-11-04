using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePipes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    //private Transform[] pipes;
    private RectTransform[] pipes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void rotatePipe(int id)
    {
        pipes[id].Rotate(0, 0, -90);
    }
}
