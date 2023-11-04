using UnityEngine;

public class Qwest_Ves1 : MonoBehaviour
{
    public float mass2;
    public Qwest_Ves QV;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stoun")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            mass2 += rb.mass;
            Debug.Log(mass2);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Stoun")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            mass2 -= rb.mass;
            Debug.Log(mass2);
        }
    }
}
