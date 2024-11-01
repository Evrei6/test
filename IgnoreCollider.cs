using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{
    public Collider targetCollider; // Коллайдер, который нужно игнорировать

    void Start()
    {
        // Игнорируем коллизии между этим объектом и targetCollider
        Physics.IgnoreCollision(GetComponent<Collider>(), targetCollider, true);
    }
}