using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInteractScript : MonoBehaviour
{
    private PlayerInput inputActions;
    private InputAction interactAction;

    [SerializeField]
    float interactionRange;
    [SerializeField]
    LayerMask InteractMask;

    Interactable interactable;
    private float interactionTime;     //Use for UI
    private float interactionProgress; //Use for UI
    private bool interactDetected;     //Use for UI
    private bool singleInteract = false;

    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Inputs
        inputActions = this.GetComponent<PlayerInput>();
        interactAction = inputActions.actions["Interact"];

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
            InteractionCheck();
        }
    }
    void InteractionCheck()
    {
        
        Collider2D[] potentialInteracts = Physics2D.OverlapCircleAll(transform.position, 1, InteractMask);
        Collider2D potentialInteract = null;
        float lastDistToP = 10000;

        foreach (Collider2D c in potentialInteracts)
        {
            float distToP = Vector2.Distance(c.transform.position, gameObject.transform.position);
            if (distToP < lastDistToP)
            {
                potentialInteract = c;
                lastDistToP = distToP;
            }
        }

        if (potentialInteract != null)
        {
            interactable = potentialInteract.gameObject.GetComponent<Interactable>();
            Debug.Log("In range");
            if (interactable.canInteract)
            {
                interactDetected = true;
                //Debug.Log("Show Interactable is: " + interactable.InteractName);
                //Send Off Interactable/Info
                CEventSystem.current.InteractionDetected(interactDetected, interactable.InteractName, interactable.InteractType, interactable.InteractTime);
            }
            else
            {
                interactDetected = false;
                CEventSystem.current.InteractionDetected(interactDetected, interactable.InteractName, interactable.InteractType, interactable.InteractTime);
            }
        }
        else
        {
            interactDetected = false;
            CEventSystem.current.InteractionDetected(interactDetected, "NA", "NA", 1f);
            interactionTime = 0;
        }

        if (interactAction.inProgress && interactDetected)
        {
            interactionTime += Time.deltaTime;
            interactionProgress = (interactionTime / interactable.InteractTime);

            if (interactionProgress >= 1)
            {
                if (!singleInteract)
                {
                    interactable.Interact(this);
                    singleInteract = true;
                }
            }
        }
        else if (!interactDetected)
        {
            interactable = null;
            interactionTime = 0;
        }
        else if (!interactAction.inProgress)
        {
            interactionTime = 0;
            singleInteract = false;
        }
        else
        {
            interactionTime = 0;
        }
    }
    private void PauseGame(bool toggle)
    {
        isPaused = toggle;
    }
}
