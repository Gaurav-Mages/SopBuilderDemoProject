using System;
using UnityEngine;

public class EventHandler : Singleton<EventHandler>
{
    public delegate void StepSelected(string StepType);
    public static event StepSelected OnStepSelected;
    
    public static void TriggerStepSelected(string StepType)
    {
        if (OnStepSelected != null)
            OnStepSelected(StepType);
        else
            Debug.LogWarning("No subscribers for StepSelected event");
    }
    
    private void OnDisable()
    {
        OnStepSelected = null;
    }
}
