using UnityEngine;

public class IgnoreCollisionWithParent : MonoBehaviour
{
    void Start()
    {
        // Получаем Collider текущего объекта
        Collider myCollider = GetComponent<Collider>();

        // Получаем родительский объект
        Transform parent = transform.parent;

        // Если у родительского объекта есть Collider, игнорируем столкновения с ним
        if (parent != null && parent.GetComponent<Collider>() != null)
        {
            Physics.IgnoreCollision(myCollider, parent.GetComponent<Collider>(), true);
        }
    }
}