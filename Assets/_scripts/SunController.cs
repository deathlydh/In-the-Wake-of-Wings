using System.Collections;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public float targetTimeOfDay; // ������� �������� ������� �����
    public float transitionSpeed; // �������� �������� ��������
    public Transform _tr;
    public float targetLightAngleX;
    private float initialTimeOfDay; // �������� �������� ������� �����
    private float startTime; // ����� ������ ��������
    private bool isTransitioning; // ���� ��������

    private void Start()
    {
        _tr = GetComponent<Transform>();
    }
    public void Cringe()
    {
        initialTimeOfDay = RenderSettings.sun.intensity;
        startTime = Time.time;
        isTransitioning = true;
    }
    private void Update()
    {
        if (isTransitioning)
        {
            float elapsedTime = Time.time - startTime;
            float t = elapsedTime / transitionSpeed;

            // �������� ������������� ������ � ������ �������� ��������
            RenderSettings.sun.intensity = Mathf.Lerp(initialTimeOfDay, targetTimeOfDay, t);

            // �������� ���� x � Transform ����� � ������ �������� ��������
            float initialLightAngleX = _tr.rotation.eulerAngles.x;
            float delta_tr = Mathf.Lerp(initialLightAngleX, targetLightAngleX, t);
            _tr.rotation = Quaternion.Euler(delta_tr, _tr.rotation.eulerAngles.y, _tr.rotation.eulerAngles.z);

            if (t >= 1f)
            {
                isTransitioning = false;
            }
        }
    }
}
