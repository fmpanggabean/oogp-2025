using UnityEngine;

public class Portal : MonoBehaviour
{
    [Tooltip("Name of scene destination")]
    [SerializeField] private string destination;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // cek kalo yang masuk portal bukan player
        Player player = collision.GetComponent<Player>();
        if (player == null)
        {
            return;
        }

        // pindah scene ke scene destination
        LevelManager.Instance.ChangeScene(destination);
    }
}
