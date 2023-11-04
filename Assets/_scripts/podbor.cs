using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class podbor : MonoBehaviour
{
    [SerializeField] private float Distance;
    [SerializeField] private LayerMask Mask;
    private Camera cam;
    [SerializeField] private Text txt;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distance, Mask))
        {
            if (hit.collider.GetComponent<interectiveObjects>())
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    hit.collider.gameObject.GetComponent<interectiveObjects>().Action();
                }
                txt.text = "ֽאזלטעו F";
            }
            else
            {
                txt.text = "";
            }

        }
        else
        {
            txt.text = "";
        }
    }
}
