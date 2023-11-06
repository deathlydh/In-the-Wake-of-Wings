using UnityEngine;
using UnityEngine.Events;

public class Scales : MonoBehaviour
{
    [SerializeField] private ScalesPlane _planeLeft;
    [SerializeField] private ScalesPlane _planeRigt;
    //public float equalityMass = 3;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private UnityEvent go;

    [SerializeField]
    private float popravkaR;
    private void OnEnable()
    {
        _planeLeft.BodyCollisionEnterEvent += CheckEquals;
        _planeRigt.BodyCollisionEnterEvent += CheckEquals;
        _planeLeft.BodyCollisionExitEvent += CheckEquals;
        _planeRigt.BodyCollisionExitEvent += CheckEquals;

        CheckEquals();
    }

    private void OnDisable()
    {
        _planeLeft.BodyCollisionEnterEvent -= CheckEquals;
        _planeRigt.BodyCollisionEnterEvent -= CheckEquals;
        _planeLeft.BodyCollisionExitEvent -= CheckEquals;
        _planeRigt.BodyCollisionExitEvent -= CheckEquals;
    }

    private void CheckEquals()
    {
        float rves = _planeRigt.BodyMass + popravkaR;
        //o = (_planeRigt.BodyMass - _planeLeft.BodyMass) / _planeLeft.BodyMass + _planeRigt.BodyMass;
        if (_planeLeft.BodyMass == /*_planeRigt.BodyMass*/rves)// && _planeRigt.BodyMass == equalityMass)
        {
            //o = 0;
            anim.SetFloat("Blend", 0);
            //Debug.Log("=)))");
            go.Invoke();
        }
        else
        {
            // anim.SetFloat("Blend", (_planeRigt.BodyMass - _planeLeft.BodyMass +0.01f) / _planeLeft.BodyMass + _planeRigt.BodyMass);
            if (_planeLeft.BodyMass > /*_planeRigt.BodyMass*/rves)
            {
                if (/*_planeRigt.BodyMass*/rves > 0)
                {
                    //o = -((_planeLeft.BodyMass-_planeRigt.BodyMass) / _planeLeft.BodyMass);
                    anim.SetFloat("Blend", -((_planeLeft.BodyMass - /*_planeRigt.BodyMass*/ rves) / _planeLeft.BodyMass));
                }
                else
                {

                    //o = -1;
                    anim.SetFloat("Blend", -1);
                }
            }
            if (_planeLeft.BodyMass < /*_planeRigt.BodyMass*/ rves)
            {
                if (_planeLeft.BodyMass > 0)
                {
                    // o = ((_planeRigt.BodyMass-_planeLeft.BodyMass) / _planeRigt.BodyMass);
                    anim.SetFloat("Blend", ((rves - _planeLeft.BodyMass) / /*_planeRigt.BodyMass*/ rves));
                }
                else
                {
                    //o = 1;
                    anim.SetFloat("Blend", 1);
                }
            }
        }
    }
}
