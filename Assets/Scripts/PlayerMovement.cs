using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private float yVelocity; // Velocidad vertical para gravedad/salto

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movimiento horizontal (WASD)
        // "Horizontal" se activa con A (-1) y D (1)
        float horizontal = Input.GetAxis("Horizontal");
        // "Vertical" se activa con S (-1) y W (1)
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = transform.TransformDirection(moveDirection) * moveSpeed;

        // Salto (Barra Espaciadora)
        if (controller.isGrounded)
        {
            yVelocity = -0.5f; // Pequeña fuerza hacia abajo para asegurar isGrounded

            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpForce;
            }
        }
        else
        {
            yVelocity -= gravity * Time.deltaTime; // Aplica gravedad
        }

        moveDirection.y = yVelocity;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
