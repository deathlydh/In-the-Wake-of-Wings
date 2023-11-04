using UnityEngine;
using UnityEngine.Events;

public class Qwest_Ves : MonoBehaviour
{
    [SerializeField]
    private UnityEvent go;

    public float mass1;
    public Qwest_Ves1 QV1;
    private bool flag = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Stoun")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            mass1 += rb.mass;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Stoun")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            mass1 -= rb.mass;
        }
    }
    private void Update()
    {
        if (mass1 == QV1.mass2 && QV1.mass2 == 3 && flag == false)
        {
            Debug.Log("ivent");
            go.Invoke();
            flag = true;
        }
    }
}
