using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    //public Animator animator;
    private PlayerController playerInput;
    private Rigidbody rb;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed = 3.0f;
    private float gravityValue = -9.81f;

    private void Awake()
    {
        playerInput = new PlayerController();
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable() { playerInput.Enable(); }

    private void OnDisable() { playerInput.Disable(); }

    void Update()
    {
        if (playerVelocity.y < 0) { playerVelocity.y = 0f; }
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(-movementInput.y, 0f, movementInput.x);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero) { gameObject.transform.forward = move; }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}