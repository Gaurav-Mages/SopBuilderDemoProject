using System.Collections.Generic;
using UnityEngine;

public class SopController : Singleton<SopController>
{
    [SerializeField] private List<SopData> _activeSopList = new List<SopData>() ;
    
    [SerializeField] private SopData _currentSop = null;

    private void Start()
    {
        EventHandler.OnStepSelected += StepSelected;
        
        FetchData();
    }
    
    public void FetchData()
    {
        List<Sop> fetchedSops = DatabaseManger.Instance.FetchSOPData();
        foreach (Sop fetchedSop in fetchedSops)
        {
            SopData fetchedSopData = fetchedSop.GetSopData();

            // Check if the SOPData with the same title already exists in _activeSopList.
            bool containsSopData = false;
            foreach (SopData activeSopData in _activeSopList)
            {
                if (activeSopData.GetTitle() == fetchedSopData.GetTitle())
                {
                    containsSopData = true;
                    if(!fetchedSop.GetIsActive())
                        _activeSopList.Remove(activeSopData);
                    
                    break;
                }
            }

            if (fetchedSop.GetIsActive() && !containsSopData)
            {
                _activeSopList.Add(fetchedSopData);
            }

        }
        
        UiManger.Instance.CreateButtons(_activeSopList);
    }

    private void StartRandomSop()
    {
        if (_currentSop == null)
        {
            Debug.Log("SOP already started: " + _currentSop.GetTitle());
            return;
        }
        
        if (_activeSopList.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, _activeSopList.Count);
            _currentSop = _activeSopList[randomIndex];
            
            Debug.Log("Random SOP started: " + _currentSop.GetTitle());
        }
        else
        {
            Debug.Log("No active SOPs available.");
        }
    }

    public void StartSop()
    {
        StartRandomSop();
    }
    
    private void StepSelected(string stepType)
    {
        if (_currentSop == null)
        {
            Debug.Log("No SOP started.");
            return;
        }
        
        if (_currentSop.CheckIfCurrentStep(stepType))
        { 
            // Step Passed
            Debug.Log("Step Passed");
            
            _currentSop.PerformStep();
        }
        else
        {
            // Step Failed
            Debug.Log("Step Failed");
          
            _currentSop = null;
          
          return;
        }
        if (_currentSop.IsSopComplete())
        {
            // Step Complete
            Debug.Log("Sop Complete");
            
            _currentSop = null;
        }
    }
}