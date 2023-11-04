using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Settings : MonoBehaviour
{
    private float val = 1f;

    void Update()
    {
        float mouseX = (float)Input.GetAxis("Mouse X") * val;
        float mouseY = (float)Input.GetAxis("Mouse Y") * val;
    }
    public void SetVolueme(float vol)
    {
        val = vol;
    }
}
