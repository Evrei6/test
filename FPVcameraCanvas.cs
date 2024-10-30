using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Transform targetObject;
    public Text heightText;
    public Text timeText;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
         // Расчет высоты
        float height = targetObject.transform.position.z;
        heightText.text = "Высота: " + height.ToString("F1") + " м";

        // Расчет времени с начала запуска сцены
        float timeElapsed = Time.time - startTime;
        timeText.text = "Время: " + timeElapsed.ToString("F2") + " с";
    }
}