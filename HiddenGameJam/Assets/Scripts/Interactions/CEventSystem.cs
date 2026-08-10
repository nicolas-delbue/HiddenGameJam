using System;
using UnityEngine;

public class CEventSystem : MonoBehaviour
{
    public static CEventSystem current;
    public void Awake()
    {
        if (current != null)
        {
            Debug.LogWarning("Two instances of EvenControllerHub in Scene");
        }
        current = this;
    }
    public event Action<bool, string, string, float> onInteractionDetected;
    public void InteractionDetected(bool detect, string name, string type, float time)
    {
        if (onInteractionDetected != null)
        {
            onInteractionDetected(detect, name, type, time);
        }
    }
    public event Action<float> onInteractionInteracting;
    public void InteractionInteracting(float time)
    {
        if (onInteractionInteracting != null)
        {
            onInteractionInteracting(time);
        }
    }
    //Pause
    public event Action<bool> onPauseInputs;
    public void PauseInputs(bool toggle)
    {
        if (onPauseInputs != null)
        {
            onPauseInputs(toggle);
        }
    }
    public event Action<bool> onCanPause;
    public void CanPause(bool toggle)
    {
        if(onCanPause != null)
        {
            onCanPause(toggle);
        }
    }
    //Canvas Events
    public event Action<bool> onWin;
    public void Win(bool toggle)
    {
        if (onWin != null)
        {
            onWin(toggle);
        }
    }
    public event Action<bool> onLose;
    public void Lose(bool toggle)
    {
        if (onLose != null)
        {
            onLose(toggle);
        }
    }
    public event Action<bool> onOpenWin;
    public void OpenWin(bool toggle)
    {
        if (onOpenWin != null)
        {
            onOpenWin(toggle);
        }
    }
    public event Action<bool> onOpenLose;
    public void OpenLose(bool toggle)
    {
        if (onOpenLose != null)
        {
            onOpenLose(toggle);
        }
    }
    public event Action<bool> onPause;
    public void Pause(bool toggle)
    {
        if (onPause != null)
        {
            onPause(toggle);
        }
    }

}