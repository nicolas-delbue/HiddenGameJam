using TMPro;
using UnityEngine;

public class InteractionUICanvas : MonoBehaviour
{
    public GameObject UIObject;
    public TextMeshProUGUI interactionText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIObject.SetActive(false);
        CEventSystem.current.onInteractionDetected += ToggleInteractionUI;
    }
    private void OnDestroy()
    {
        CEventSystem.current.onInteractionDetected -= ToggleInteractionUI;
    }

    private void ToggleInteractionUI(bool detect, string name, string type, float time)
    {
        UIObject.SetActive(detect);
        interactionText.text = name;
    }
}
