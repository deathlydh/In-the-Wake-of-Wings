using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class rotatePipes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] pipes;
    //private RectTransform[] pipes;
    [SerializeField]
    private UnityEvent go;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotatePipes3d(GameObject obj)
    {
        obj.transform.Rotate(0, 0, -90);
        checkPipes();
    }
    private void checkPipes()
    {
        if (pipes[0].eulerAngles.z == 270  & pipes[1].eulerAngles.z == 90 & (pipes[2].eulerAngles.z == 0 | pipes[2].eulerAngles.z == 180) & pipes[3].eulerAngles.z == 0 & (pipes[4].eulerAngles.z == 90 | pipes[4].eulerAngles.z == 270) & pipes[5].eulerAngles.z == 180 & (pipes[6].eulerAngles.z == 180 | pipes[6].eulerAngles.z == 0) & pipes[7].eulerAngles.z == 270 & pipes[8].eulerAngles.z == 90)
        {
            go.Invoke();
        }
    }
}
