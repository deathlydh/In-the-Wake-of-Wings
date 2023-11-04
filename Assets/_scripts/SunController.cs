using System.Collections;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public float targetTimeOfDay; // Целевое значение времени суток
    public float transitionSpeed; // Скорость плавного перехода
    public Transform _tr;
    public float targetLightAngleX;
    private float initialTimeOfDay; // Исходное значение времени суток
    private float startTime; // Время начала перехода
    private bool isTransitioning; // Флаг перехода

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

            // Изменяем интенсивность солнца с учетом плавного перехода
            RenderSettings.sun.intensity = Mathf.Lerp(initialTimeOfDay, targetTimeOfDay, t);

            // Изменяем угол x у Transform света с учетом плавного перехода
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
