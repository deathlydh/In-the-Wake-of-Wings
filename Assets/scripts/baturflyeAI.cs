using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class baturflyeAI : MonoBehaviour
{
    [SerializeField]
    private float distace;
    [SerializeField]
    private float dist;
    [SerializeField]
    private float distPath;
    [SerializeField]
    private path curPath;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position,transform.position);
        distPath = Vector3.Distance(curPath.transform.position, transform.position);
        if (dist < distace & distPath > 1)
        {
            transform.position += (curPath.transform.position - transform.position).normalized * speed * Time.deltaTime;
            transform.LookAt(curPath.transform.position, Vector3.up);

        }
        else
        {
            if (distPath < 1)
            {
                curPath = curPath.NextPath;
            }
        }
    }
}
