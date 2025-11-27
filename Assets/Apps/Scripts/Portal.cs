using UnityEngine;

public class Portal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject triggeringObject = collision.gameObject;
    }
}
