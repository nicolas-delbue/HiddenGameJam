using UnityEngine;

public class LinkingInteractable : Interactable
{
    [SerializeField] private NonInteractable nonInteractableObj;
    public AudioClip press;
    private bool switchEffect;
    public override void Initialize()
    {
        base.Initialize();
        switchEffect = false;
    }
    protected override void HandleInteraction(PlayerInteractScript interactor)
    {
        AudioHandler.instance.PlaySoundEffect(press, transform, 1f);
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
