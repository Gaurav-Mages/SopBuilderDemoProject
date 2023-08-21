using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sop
{
    [SerializeField] private bool _isActive;
    [SerializeField] private SopData _sopData;
    
    public bool GetIsActive()
    {
        return _isActive;
    }
    
    public SopData GetSopData()
    {
        return _sopData;
    }
}

[System.Serializable]
public class SopData
{
    [SerializeField] private string _title;
    [SerializeField] private Texture2D _image;
    [SerializeField] private CutScene _cutScene;
    
    [SerializeField] private List<Step> _steps;
    
    private int _stepCountToMatch = 0;

    public string GetTitle()
    {
        return _title;
    }

    public Texture2D GetImage()
    {
        return _image;
    }
        
    public List<Step> GetSteps()
    {
        return _steps;
    }

    public bool CheckIfCurrentStep(string stepType)
    {
        if (stepType != _steps[_stepCountToMatch].GetTitle())
            return false;
        return true;
    }
    
    public bool IsSopComplete()
    {
        if (_stepCountToMatch == _steps.Count)
            return true;
        return false;
    }

    public void PerformStep()
    {
        _steps[_stepCountToMatch].DoStep();
        IncreaseStepToMatch();
    }
    
    private void IncreaseStepToMatch()
    {
        _stepCountToMatch++;
    }
}

[System.Serializable]
public class CutScene
{
    [SerializeField] private string _title;
}