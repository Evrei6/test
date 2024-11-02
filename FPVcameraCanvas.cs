using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Transform targetObject;
    public Text heightText;
    public Text timeText;
    public Text speedText; // Добавлен Text для скорости

    private float startTime; // Время начала работы дрона
    private bool isDroneActive = false; // Флаг активности дрона
    private float speedSum = 0f; // Сумма скоростей за последние кадры
    private int framesCount = 0; // Количество кадров для усреднения
    private Vector3 lastPosition; // Для хранения предыдущей позиции

    void Start()
    {
        // Инициализируем lastPosition для расчета скорости
        lastPosition = targetObject.position; 
    }

    void Update()
    {
        // Расчет высоты
        float height = targetObject.transform.position.z;
        heightText.text = "Высота: " + height.ToString("F1") + " м";

        // Расчет скорости (используем усреднение, как в предыдущем примере)
        float speed = Mathf.Abs(targetObject.position.x - lastPosition.x) / Time.deltaTime;
        speedSum += speed;
        framesCount++;
        if (framesCount >= 5)
        {
            float averageSpeed = speedSum / framesCount;
            float speedKmh = averageSpeed * 3.6f;
            speedText.text = "Скорость: " + speedKmh.ToString("F2") + " км/ч";
            speedSum = 0f;
            framesCount = 0;
        }
        lastPosition = targetObject.position;

        // Управление временем работы дрона
        if (isDroneActive)
        {
            // Если дрон активен, считаем время работы
            float timeElapsed = Time.time - startTime;
            timeText.text = "Время: " + timeElapsed.ToString("F2") + " с";
        }
        else
        {
            // Если дрон не активен, очищаем время
            timeText.text = "Время: 0.00 с";
        }
    }

    // Функция, которая вызывается при нажатии на пульт (нужно реализовать ее в другом скрипте)
    public void ActivateDrone()
    {
        isDroneActive = true;
        startTime = Time.time; 
    }

    // Функция, которая вызывается при отпускании пульта (нужно реализовать ее в другом скрипте)
    public void DeactivateDrone()
    {
        isDroneActive = false;
    }
}