using UnityEngine;

public class NonInteractableDoor : NonInteractable
{
    private Vector3 originalSpot;
    [SerializeField] private Vector3 newSpot;
    private void Start()
    {
        originalSpot = gameObject.transform.position;
    }
    public override void OnActivate()
    {
        OpenDoor();
    }
    public override void OnDeactivate()
    {
        CloseDoor();
    }
    public void OpenDoor()
    {
        gameObject.transform.position = newSpot;
    }
    public void CloseDoor()
    {
        gameObject.transform.position = originalSpot;
    }
}
