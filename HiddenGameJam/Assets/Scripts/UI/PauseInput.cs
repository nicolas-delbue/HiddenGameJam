using UnityEngine;
using UnityEngine.InputSystem;

public class PauseInput : MonoBehaviour
{
    private PlayerInput inputActions;
    private InputAction menuAction;

    private bool isPaused = false;
    private bool canPause = true;
    void Start()
    {
        //Inputs
        inputActions = this.GetComponent<PlayerInput>();
        menuAction = inputActions.actions["Pause"];
        menuAction.performed += openPauseMenu;
        isPaused = false;
        canPause = true;

        CEventSystem.current.onCanPause += TogglePause;
    }
    private void OnDestroy()
    {
        menuAction.performed -= openPauseMenu;
    }
    private void openPauseMenu(InputAction.CallbackContext c)
    {
        if(c.performed && canPause)
        {
            isPaused = !isPaused;
            CEventSystem.current.Pause(isPaused);
        }
    }
    private void TogglePause(bool toggle)
    {
        canPause = toggle;
    }
}
