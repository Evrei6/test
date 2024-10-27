using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float trackingSpeed = 5f; // Скорость поворота камеры
    public bool isTracking = false; // Флаг активации слежения
    public float raycastDistance = 10f; // Расстояние для луча
    public string controlKey = "space"; // Строка для названия клавиши

    private float xRotation = 0f;
    private Vector3 targetPoint; // Точка, на которую камера смотрит

    void Update()
    {
        // Проверка нажатия заданной кнопки
        if (Input.GetKeyDown(controlKey))
        {
            // Обновление точки на поверхности
            RaycastHit hit;
            // Получаем направление взгляда игрока
            Vector3 playerForward = transform.forward;
            // Выпускаем луч от позиции игрока в направлении его взгляда
            if (Physics.Raycast(transform.position, playerForward, out hit, raycastDistance))
            {
                targetPoint = hit.point;
            }

            // Включение/выключение отслеживания
            isTracking = !isTracking; 
        }

        // Если отслеживание активно
        if (isTracking)
        {
            // Вычисление направления на целевую точку
            Vector3 direction = targetPoint - transform.position;

            // Поворот камеры в направлении цели
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), trackingSpeed * Time.deltaTime);
        }
        else
        {
            // Вращение камеры с помощью мыши
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            Camera.main.transform.Rotate(Vector3.up * mouseX);
        }
    }
}