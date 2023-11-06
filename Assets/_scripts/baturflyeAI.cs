using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.CinemachineTargetGroup;
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
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private EventReference waitEvent;
    [SerializeField]
    private EventReference goEvent;
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
            anim.SetBool("wait", false);
            //RuntimeManager.PlayOneShot(goEvent, this.gameObject.transform.position);
            transform.position += (curPath.transform.position - transform.position).normalized * speed * Time.deltaTime;
            transform.LookAt(curPath.transform.position, Vector3.up);

        }
        else
        {
            if (distPath < 1)
            {
                if (curPath.isStop)
                {
                    //Destroy(gameObject);
                    anim.SetBool("wait", true);
                    RuntimeManager.PlayOneShotAttached(waitEvent, this.gameObject);

                    //transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
                }
                else
                {
                    anim.SetBool("wait", false);
                    RuntimeManager.PlayOneShot(goEvent, this.gameObject.transform.position);
                    curPath = curPath.NextPath;
                }
            }
            else
            {
                 if (dist > distace)
                 {
                     anim.SetBool("wait", true);
                    // RuntimeManager.PlayOneShotAttached(waitEvent, this.gameObject);
                }
            }
        }
    }
    public void LetsGoNextPath()
    {
        speed = 5;
        curPath.isStop = false;
    }
}
