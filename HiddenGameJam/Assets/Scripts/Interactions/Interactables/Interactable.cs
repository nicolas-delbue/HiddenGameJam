using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private bool _isInitialized; //Will have a use when level item manager exists

    [SerializeField]
    protected float _interactTime = 0;
    [SerializeField]
    protected string _interactableName = "NA";
    [SerializeField]
    protected string _interactionType = "NA";
    public float InteractTime => _interactTime;
    public string InteractName => _interactableName;
    public string InteractType => _interactionType;
    public bool canInteract = true;

    public virtual void Initialize()
    {
        _isInitialized = true;
    }
    protected virtual void OnDestroy()
    {
        Dispose();
    }
    protected virtual void Dispose()
    {
        _isInitialized = false;
    }
    protected virtual void Start()
    {
        Initialize();
    }
    public void Interact(PlayerInteractScript interactor)
    {
        HandleInteraction(interactor);
    }

    protected virtual void Update()
    {

    }

    protected abstract void HandleInteraction(PlayerInteractScript interactor);
}
