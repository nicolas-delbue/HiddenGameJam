using UnityEngine;

public class WinAreaInteraction : Interactable
{
    protected override void HandleInteraction(PlayerInteractScript interactor)
    {
        Debug.Log("Win Game After This. Loc: WinAreaInteraction.cs at Line: 7");
        //First it will just be go to main menu
        //Later Add level completion to a static info script so it will save which level is completed or not
    }
}
