using System.Collections;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public float targetTimeOfDay; // Целевое значение времени суток
    public float transitionSpeed; // Скорость плавного перехода
    public Transform lightTransform; // Ссылка на Transform света
    private float initialLightAngleY;
    private float initialLightAngleZ;
    private float initialTimeOfDay; // Исходное значение времени суток
    private float startTime; // Время начала перехода
    private bool isTransitioning; // Флаг перехода
    public float targetLightAngleX;    public float targetLightAngleY;    public float targetLightAngleZ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTransition(); // Запускаем плавную смену времени суток
        }
    }

    private IEnumerator TransitionCoroutine()
    {
        float elapsedTime = 0f;

        // Устанавливаем начальное значение угла X у Transform света
        float initialLightAngleX = lightTransform.rotation.eulerAngles.x;

        while (elapsedTime < transitionSpeed)
        {
            float t = elapsedTime / transitionSpeed;

            // Изменяем интенсивность солнца с учетом плавного перехода
            RenderSettings.sun.intensity = Mathf.Lerp(initialTimeOfDay, targetTimeOfDay, t);

            // Изменяем угол X у Transform света с учетом плавного перехода
             // Устанавливаем конечное значение угла X
            float delta_tr = Mathf.Lerp(initialLightAngleX, targetLightAngleX, t);
            float delta_trY = Mathf.Lerp(initialLightAngleY, targetLightAngleY, t);
            float delta_trZ = Mathf.Lerp(initialLightAngleZ, targetLightAngleZ, t);
            Quaternion newRotation = Quaternion.Euler(delta_tr, delta_trY, delta_trZ);
            lightTransform.rotation = newRotation;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Устанавливаем конечное значение интенсивности солнца
        RenderSettings.sun.intensity = targetTimeOfDay;

        isTransitioning = false;
    }
    private void StartTransition()
    {
        // Получаем текущий угол Y для света
        initialLightAngleY = lightTransform.rotation.eulerAngles.y;
        initialTimeOfDay = RenderSettings.sun.intensity;
        startTime = Time.time;
        isTransitioning = true;

        StartCoroutine(TransitionCoroutine());
    }
}