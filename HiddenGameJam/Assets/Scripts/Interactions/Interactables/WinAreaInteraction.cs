using UnityEngine;

public class WinAreaInteraction : Interactable
{
    protected override void HandleInteraction(PlayerInteractScript interactor)
    {
        Debug.Log("Win Game After This. Loc: WinAreaInteraction.cs at Line: 7");
    }
}
