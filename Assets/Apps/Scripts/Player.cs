using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D Rigidbody2D;
    private PlayerInput PlayerInput;

    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        PlayerInput = GetComponent<PlayerInput>();
    }

    void OnEnable()
    {
        PlayerInput.actions["Move"].performed += SetDirection;
        PlayerInput.actions["Move"].canceled += SetDirection;
    }

    void OnDisable()
    {
        PlayerInput.actions["Move"].performed -= SetDirection;
        PlayerInput.actions["Move"].canceled -= SetDirection;
    }

    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D.linearVelocity = direction * speed;
    }

    public void SetDirection(CallbackContext ctx)
    {
        if (ctx.performed || ctx.canceled)
        {
            SetDirection(ctx.ReadValue<Vector2>());
        }
    }
}
