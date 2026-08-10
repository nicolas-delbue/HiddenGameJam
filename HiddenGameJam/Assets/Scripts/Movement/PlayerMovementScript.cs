using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction playerMove;
    private bool isPaused = false;

    private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerMove = playerInput.actions["Move"];
        isPaused = false;
        CEventSystem.current.onPauseInputs += PauseGame;
    }
    private void OnDestroy()
    {
        CEventSystem.current.onPauseInputs -= PauseGame;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPaused)
        {
            MovementUpdate();
        }
    }
    private void MovementUpdate()
    {
        Vector2 move = playerMove.ReadValue<Vector2>();
        rb2d.linearVelocity = new Vector2(move.x * moveSpeed, move.y * moveSpeed);
    }
    private void PauseGame(bool toggle)
    {
        isPaused = toggle;
        rb2d.linearVelocity = Vector2.zero;
    }
}
