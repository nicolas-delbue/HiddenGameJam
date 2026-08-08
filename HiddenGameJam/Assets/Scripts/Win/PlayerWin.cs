using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    [SerializeField] private WinAreaInteraction winInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == PlayerTag)
        {
            //Turn on Interactable Component
            winInteract.canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == PlayerTag)
        {
            //Turn off Interactable Component
            winInteract.canInteract = false;
        }
    }
}
