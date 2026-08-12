using UnityEngine;

public class LinkingInteractable : Interactable
{
    [SerializeField] private NonInteractable nonInteractableObj;
    private bool switchEffect;
    public override void Initialize()
    {
        base.Initialize();
        switchEffect = false;
    }
    protected override void HandleInteraction(PlayerInteractScript interactor)
    {
        if(!switchEffect)
        {
            nonInteractableObj.OnActivate();
        }
        else
        {
            nonInteractableObj.OnDeactivate();
        }
    }
}
