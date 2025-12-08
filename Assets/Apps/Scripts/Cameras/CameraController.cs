using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    private CinemachineCamera cinemachineCamera;

    void Awake()
    {
        Instance = this;

        cinemachineCamera = GetComponentInChildren<CinemachineCamera>();
    }

    void Start()
    {
        SetFocusTo(FindFirstObjectByType<Player>().transform);
    }

    public void SetFocusTo(Transform target)
    {
        cinemachineCamera.Follow = target;
    }
}
