using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider rotationSpeedHorSlider;
    public Slider rotationSpeedVerSlider;
    public Mause_Luck mauseLuckScript;

    private void Start()
    {
        rotationSpeedHorSlider.onValueChanged.AddListener(delegate { OnRotationSpeedHorChanged(); });
        rotationSpeedVerSlider.onValueChanged.AddListener(delegate { OnRotationSpeedVerChanged(); });
    }

    public void OnRotationSpeedHorChanged()
    {
        if (mauseLuckScript != null)
        {
            mauseLuckScript.SetRotationSpeedHor(rotationSpeedHorSlider.value);
        }
    }

    public void OnRotationSpeedVerChanged()
    {
        if (mauseLuckScript != null)
        {
            mauseLuckScript.SetRotationSpeedVer(rotationSpeedVerSlider.value);
        }
    }
}

