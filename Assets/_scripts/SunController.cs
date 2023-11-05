using System.Collections;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public float targetTimeOfDay; // ������� �������� ������� �����
    public float transitionSpeed; // �������� �������� ��������
    public Transform lightTransform; // ������ �� Transform �����
    private float initialLightAngleY;
    private float initialLightAngleZ;
    private float initialTimeOfDay; // �������� �������� ������� �����
    private float startTime; // ����� ������ ��������
    private bool isTransitioning; // ���� ��������
    public float targetLightAngleX;    public float targetLightAngleY;    public float targetLightAngleZ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTransition(); // ��������� ������� ����� ������� �����
        }
    }

    private IEnumerator TransitionCoroutine()
    {
        float elapsedTime = 0f;

        // ������������� ��������� �������� ���� X � Transform �����
        float initialLightAngleX = lightTransform.rotation.eulerAngles.x;

        while (elapsedTime < transitionSpeed)
        {
            float t = elapsedTime / transitionSpeed;

            // �������� ������������� ������ � ������ �������� ��������
            RenderSettings.sun.intensity = Mathf.Lerp(initialTimeOfDay, targetTimeOfDay, t);

            // �������� ���� X � Transform ����� � ������ �������� ��������
             // ������������� �������� �������� ���� X
            float delta_tr = Mathf.Lerp(initialLightAngleX, targetLightAngleX, t);
            float delta_trY = Mathf.Lerp(initialLightAngleY, targetLightAngleY, t);
            float delta_trZ = Mathf.Lerp(initialLightAngleZ, targetLightAngleZ, t);
            Quaternion newRotation = Quaternion.Euler(delta_tr, delta_trY, delta_trZ);
            lightTransform.rotation = newRotation;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ������������� �������� �������� ������������� ������
        RenderSettings.sun.intensity = targetTimeOfDay;

        isTransitioning = false;
    }
    private void StartTransition()
    {
        // �������� ������� ���� Y ��� �����
        initialLightAngleY = lightTransform.rotation.eulerAngles.y;
        initialTimeOfDay = RenderSettings.sun.intensity;
        startTime = Time.time;
        isTransitioning = true;

        StartCoroutine(TransitionCoroutine());
    }
}