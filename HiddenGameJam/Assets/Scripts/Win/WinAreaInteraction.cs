using UnityEngine;

public class WinAreaInteraction : Interactable
{
    protected override void HandleInteraction(PlayerInteractScript interactor)
    {
        //Event to Canvas to show screen, and to GameManager to log win and unlock next level
        CEventSystem.current.Win(true);
    }
}
