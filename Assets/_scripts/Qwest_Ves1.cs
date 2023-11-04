using UnityEngine;

public class Qwest_Ves1 : MonoBehaviour
{
    public float mass2;
    public Qwest_Ves QV;
    private void OnTriggerEnter(Collider other)
    {

         Rigidbody rb = other.GetComponent<Rigidbody>();
         mass2 += rb.mass;

    }
    private void OnTriggerExit(Collider other)
    {


        Rigidbody rb = other.GetComponent<Rigidbody>();
        mass2 -= rb.mass;

    }
}
